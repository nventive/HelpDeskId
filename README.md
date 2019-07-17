# HelpDeskId

Generates identifiers that humans can exchange easily.

The objective for this library is to be able to generate identifiers that can be communicated
to humans in case of error.
Some systems generate an Operation/Error Id (a GUID-like string), but it is usually
rather cumbersome to communicate either orally or via a screenshot.
This allows you to generate identifiers in the form of triplets of common words (e.g. "moon-shadow-list").

**Be aware though that these identifiers are not guaranteed to be unique. There are not a replacement for GUIDs.**

[![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](LICENSE)
[![Build Status](https://dev.azure.com/nventive-public/nventive/_apis/build/status/nventive.HelpDeskId?branchName=master)](https://dev.azure.com/nventive-public/nventive/_build/latest?definitionId=2&branchName=master)
![Nuget](https://img.shields.io/nuget/v/HelpDeskId.svg)

## Getting Started

Install the package:

```
Install-Package HelpDeskId
```

```csharp
var generator = new HelpDeskIdGenerator();

// Generate an id using the CultureInfo.CurrentCulture if available with a fallback to english words.
var helpDeskId = generator.GenerateReadableId(); // "desk-plastic-record"

// Specify the source dictionary to use, in this case french words.
helpDeskId = generator.GenerateReadableId(CultureInfo.GetCultureInfo("fr")); // "essayer-debut-avancer"
```

## Features

- The number of words and the separator can be customized in the constructor:
```csharp
var generator = new HelpDeskIdGenerator(numberOfWords: 2, separator: "/");
var helpDeskId = generator.GenerateReadableId(); // "another/one"
```

- Currently, only english (default) and french ("fr") source words are supported (PR welcomed!).
They represent common words in these languages, where swear words have been curated.
The list can be customized by providing a `IWordsProvider` implementation.

## Changelog

Please consult the [CHANGELOG](CHANGELOG.md) for more information about version history.

## License

This project is licensed under the Apache 2.0 license - see the [LICENSE](LICENSE) file for details.

## Contributing

Please read [CONTRIBUTING.md](CONTRIBUTING.md) for details on the process for contributing to this project.

Be mindful of our [Code of Conduct](CODE_OF_CONDUCT.md).
