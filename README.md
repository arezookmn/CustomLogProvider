# CustomLogProvider
in This project, i provide an implementation of log provider interface, enabling colored message logging to the console.  Future updates will expand the project's capabilities by incorporating additional logging destinations.

# Alogger

Alogger is a logging solution that allows customization of logging destinations through the implementation of the `ILogProvider` interface. Currently, it provides functionality to log messages to the console in a visually appealing and colorful manner.

## Features

- **Customizable Logging**: Configure logging behavior through the `ALog` section in the `appsettings.json` file.
  
- **Colorized Console Logging**: Alogger enhances console logging by applying colorization to messages, ensuring improved readability.
  
- **Scalable Architecture**: Designed with extensibility in mind, Alogger is built to accommodate future enhancements and the addition of new logging destinations.

## Usage

To configure Alogger, simply add the following settings to your `appsettings.json` file:

```json
"ALog": {
  "LogTo": "Console",
  "LogLevel": "Information"
}
```

Where:
- `"LogTo"` specifies the destination for logging (currently supporting only `"Console"`).
- `"LogLevel"` sets the minimum log level for messages to be logged.


To integrate Alogger into your application, clear the existing logging providers and add the custom `ALogProvider` to your `Program.cs` class:

```csharp
builder.Logging.ClearProviders();
builder.Logging.AddProvider(new ALogProvider(builder.Configuration));
```

## Contribution

Contributions to Alogger are welcome! Whether it's bug fixes, feature enhancements, or suggestions, feel free to open an issue or submit a pull request. Your input helps make Alogger better for everyone.

## Reporting Issues

If you encounter any issues or have suggestions for improvement, please don't hesitate to open an issue on GitHub. Your feedback is invaluable in improving the quality of Alogger.
