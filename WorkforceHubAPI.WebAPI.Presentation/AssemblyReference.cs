namespace WorkforceHubAPI.WebAPI.Presentation;

/// <summary>
/// A static class used as a marker to reference this assembly in clean architecture projects.
/// </summary>
/// <remarks>
/// This class does not contain any functionality. It exists primarily to serve as an anchor point for
/// referencing this assembly in other parts of the application. For example, it is used to register controllers
/// from this assembly dynamically in the Program class:
///
/// <code>
/// builder
///     .Services.AddControllers()
///     .AddApplicationPart(typeof(WorkforceHubAPI.WebAPI.Presentation.AssemblyReference).Assembly);
/// </code>
///
/// This approach ensures that controllers in this assembly are included in the application's execution,
/// even when using seperate class libraries for presentation layers in clean architecture.
/// </remarks>
public static class AssemblyReference { }
