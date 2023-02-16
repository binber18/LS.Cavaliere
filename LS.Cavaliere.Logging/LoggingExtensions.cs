using JetBrains.Annotations;
// ReSharper disable All
namespace Microsoft.Extensions.Logging;
[System.CodeDom.Compiler.GeneratedCode("https://generators.schmiedicke.dev", "1.2.0.0")]
public static class LoggingExtensions 
{
	public static void Log(this ILogger logger, Microsoft.Extensions.Logging.LogLevel level, [StructuredMessageTemplate] string? message)
	{
		if(!logger.IsEnabled(level))
			return;
		Microsoft.Extensions.Logging.LoggerExtensions.Log(logger, level, message);
	}
	public static void LogTrace(this ILogger logger, [StructuredMessageTemplate] string? message) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Trace, message);
	public static void LogDebug(this ILogger logger, [StructuredMessageTemplate] string? message) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Debug, message);
	public static void LogInformation(this ILogger logger, [StructuredMessageTemplate] string? message) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Information, message);
	public static void LogWarning(this ILogger logger, [StructuredMessageTemplate] string? message) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Warning, message);
	public static void LogError(this ILogger logger, [StructuredMessageTemplate] string? message) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Error, message);
	public static void LogCritical(this ILogger logger, [StructuredMessageTemplate] string? message) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Critical, message);

	public static void Log<T1>(this ILogger logger, Microsoft.Extensions.Logging.LogLevel level, string? message, T1 arg1)
	{
		if(!logger.IsEnabled(level))
			return;
		Microsoft.Extensions.Logging.LoggerExtensions.Log(logger, level, message, arg1);
	}
	public static void LogTrace<T1>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Trace, message, arg1);
	public static void LogDebug<T1>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Debug, message, arg1);
	public static void LogInformation<T1>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Information, message, arg1);
	public static void LogWarning<T1>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Warning, message, arg1);
	public static void LogError<T1>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Error, message, arg1);
	public static void LogCritical<T1>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Critical, message, arg1);

	public static void Log<T1, T2>(this ILogger logger, Microsoft.Extensions.Logging.LogLevel level, string? message, T1 arg1, T2 arg2)
	{
		if(!logger.IsEnabled(level))
			return;
		Microsoft.Extensions.Logging.LoggerExtensions.Log(logger, level, message, arg1, arg2);
	}
	public static void LogTrace<T1, T2>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Trace, message, arg1, arg2);
	public static void LogDebug<T1, T2>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Debug, message, arg1, arg2);
	public static void LogInformation<T1, T2>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Information, message, arg1, arg2);
	public static void LogWarning<T1, T2>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Warning, message, arg1, arg2);
	public static void LogError<T1, T2>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Error, message, arg1, arg2);
	public static void LogCritical<T1, T2>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Critical, message, arg1, arg2);

	public static void Log<T1, T2, T3>(this ILogger logger, Microsoft.Extensions.Logging.LogLevel level, string? message, T1 arg1, T2 arg2, T3 arg3)
	{
		if(!logger.IsEnabled(level))
			return;
		Microsoft.Extensions.Logging.LoggerExtensions.Log(logger, level, message, arg1, arg2, arg3);
	}
	public static void LogTrace<T1, T2, T3>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Trace, message, arg1, arg2, arg3);
	public static void LogDebug<T1, T2, T3>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Debug, message, arg1, arg2, arg3);
	public static void LogInformation<T1, T2, T3>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Information, message, arg1, arg2, arg3);
	public static void LogWarning<T1, T2, T3>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Warning, message, arg1, arg2, arg3);
	public static void LogError<T1, T2, T3>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Error, message, arg1, arg2, arg3);
	public static void LogCritical<T1, T2, T3>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Critical, message, arg1, arg2, arg3);

	public static void Log<T1, T2, T3, T4>(this ILogger logger, Microsoft.Extensions.Logging.LogLevel level, string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
	{
		if(!logger.IsEnabled(level))
			return;
		Microsoft.Extensions.Logging.LoggerExtensions.Log(logger, level, message, arg1, arg2, arg3, arg4);
	}
	public static void LogTrace<T1, T2, T3, T4>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Trace, message, arg1, arg2, arg3, arg4);
	public static void LogDebug<T1, T2, T3, T4>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Debug, message, arg1, arg2, arg3, arg4);
	public static void LogInformation<T1, T2, T3, T4>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Information, message, arg1, arg2, arg3, arg4);
	public static void LogWarning<T1, T2, T3, T4>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Warning, message, arg1, arg2, arg3, arg4);
	public static void LogError<T1, T2, T3, T4>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Error, message, arg1, arg2, arg3, arg4);
	public static void LogCritical<T1, T2, T3, T4>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Critical, message, arg1, arg2, arg3, arg4);

	public static void Log<T1, T2, T3, T4, T5>(this ILogger logger, Microsoft.Extensions.Logging.LogLevel level, string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
	{
		if(!logger.IsEnabled(level))
			return;
		Microsoft.Extensions.Logging.LoggerExtensions.Log(logger, level, message, arg1, arg2, arg3, arg4, arg5);
	}
	public static void LogTrace<T1, T2, T3, T4, T5>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Trace, message, arg1, arg2, arg3, arg4, arg5);
	public static void LogDebug<T1, T2, T3, T4, T5>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Debug, message, arg1, arg2, arg3, arg4, arg5);
	public static void LogInformation<T1, T2, T3, T4, T5>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Information, message, arg1, arg2, arg3, arg4, arg5);
	public static void LogWarning<T1, T2, T3, T4, T5>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Warning, message, arg1, arg2, arg3, arg4, arg5);
	public static void LogError<T1, T2, T3, T4, T5>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Error, message, arg1, arg2, arg3, arg4, arg5);
	public static void LogCritical<T1, T2, T3, T4, T5>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Critical, message, arg1, arg2, arg3, arg4, arg5);

	public static void Log<T1, T2, T3, T4, T5, T6>(this ILogger logger, Microsoft.Extensions.Logging.LogLevel level, string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
	{
		if(!logger.IsEnabled(level))
			return;
		Microsoft.Extensions.Logging.LoggerExtensions.Log(logger, level, message, arg1, arg2, arg3, arg4, arg5, arg6);
	}
	public static void LogTrace<T1, T2, T3, T4, T5, T6>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Trace, message, arg1, arg2, arg3, arg4, arg5, arg6);
	public static void LogDebug<T1, T2, T3, T4, T5, T6>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Debug, message, arg1, arg2, arg3, arg4, arg5, arg6);
	public static void LogInformation<T1, T2, T3, T4, T5, T6>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Information, message, arg1, arg2, arg3, arg4, arg5, arg6);
	public static void LogWarning<T1, T2, T3, T4, T5, T6>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Warning, message, arg1, arg2, arg3, arg4, arg5, arg6);
	public static void LogError<T1, T2, T3, T4, T5, T6>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Error, message, arg1, arg2, arg3, arg4, arg5, arg6);
	public static void LogCritical<T1, T2, T3, T4, T5, T6>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Critical, message, arg1, arg2, arg3, arg4, arg5, arg6);

	public static void Log<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, Microsoft.Extensions.Logging.LogLevel level, string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
	{
		if(!logger.IsEnabled(level))
			return;
		Microsoft.Extensions.Logging.LoggerExtensions.Log(logger, level, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
	}
	public static void LogTrace<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Trace, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
	public static void LogDebug<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Debug, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
	public static void LogInformation<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Information, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
	public static void LogWarning<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Warning, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
	public static void LogError<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Error, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
	public static void LogCritical<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Critical, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7);

	public static void Log<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, Microsoft.Extensions.Logging.LogLevel level, string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
	{
		if(!logger.IsEnabled(level))
			return;
		Microsoft.Extensions.Logging.LoggerExtensions.Log(logger, level, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
	}
	public static void LogTrace<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Trace, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
	public static void LogDebug<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Debug, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
	public static void LogInformation<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Information, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
	public static void LogWarning<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Warning, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
	public static void LogError<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Error, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
	public static void LogCritical<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Critical, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);

	public static void Log<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, Microsoft.Extensions.Logging.LogLevel level, string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
	{
		if(!logger.IsEnabled(level))
			return;
		Microsoft.Extensions.Logging.LoggerExtensions.Log(logger, level, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
	}
	public static void LogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Trace, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
	public static void LogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Debug, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
	public static void LogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Information, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
	public static void LogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Warning, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
	public static void LogError<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Error, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
	public static void LogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Critical, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);

	public static void Log<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, Microsoft.Extensions.Logging.LogLevel level, string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
	{
		if(!logger.IsEnabled(level))
			return;
		Microsoft.Extensions.Logging.LoggerExtensions.Log(logger, level, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
	}
	public static void LogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Trace, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
	public static void LogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Debug, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
	public static void LogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Information, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
	public static void LogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Warning, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
	public static void LogError<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Error, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
	public static void LogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, [StructuredMessageTemplate] string? message, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10) => Log(logger, Microsoft.Extensions.Logging.LogLevel.Critical, message, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);

}
