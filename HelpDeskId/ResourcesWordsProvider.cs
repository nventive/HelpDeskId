using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace HelpDeskId
{
    /// <summary>
    /// <see cref="IWordsProvider"/> implementation that uses embedded resources.
    /// </summary>
    public class ResourcesWordsProvider : IWordsProvider
    {
        private readonly IDictionary<string, string[]> _loadedResources = new Dictionary<string, string[]>();
        private readonly Random _random;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourcesWordsProvider"/> class.
        /// </summary>
        /// <param name="seed">The <see cref="Random"/> seed to use.</param>
        public ResourcesWordsProvider(int? seed = null)
        {
            _random = seed == null ? new Random() : new Random(seed.Value);
        }

        /// <inheritdoc />
        public IEnumerable<string> GetWords(int numberOfWords, CultureInfo cultureInfo)
        {
            var words = GetResources(cultureInfo);
            var pickedWords = new string[numberOfWords];
            for (var i = 0; i < numberOfWords; i++)
            {
                pickedWords[i] = words[_random.Next(words.Length)];
            }

            return pickedWords;
        }

        private string[] GetResources(CultureInfo cultureInfo)
        {
            var cultureInfoName = cultureInfo.Name;
            if (_loadedResources.ContainsKey(cultureInfoName))
            {
                return _loadedResources[cultureInfoName];
            }

            lock (_loadedResources)
            {
                if (_loadedResources.ContainsKey(cultureInfoName))
                {
                    return _loadedResources[cultureInfoName];
                }

                var baseAssembly = typeof(ResourcesWordsProvider).Assembly;
                Assembly assembly = null;
                do
                {
                    try
                    {
                        assembly = string.IsNullOrEmpty(cultureInfo.Name)
                            ? baseAssembly
                            : baseAssembly.GetSatelliteAssembly(cultureInfo);
                    }
                    catch (FileNotFoundException)
                    {
                    }
                    catch (FileLoadException)
                    {
                    }
                    finally
                    {
                        cultureInfo = cultureInfo.Parent;
                    }
                }
                while (assembly == null || !string.IsNullOrEmpty(cultureInfo.Parent.Name));

                using (var reader = new StreamReader(assembly.GetManifestResourceStream($"HelpDeskId.Resources.Words.txt")))
                {
                    var words = reader.ReadToEnd().Split(' ');
                    _loadedResources[cultureInfoName] = words;
                    return words;
                }
            }
        }
    }
}
