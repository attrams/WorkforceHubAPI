using System.ComponentModel;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WorkforceHubAPI.WebAPI.Presentation.ModelBinders;

/// <summary>
/// A custom model binder for binding comma-seperated values from the query string
/// to an enumerable model type, such as an array or list.
/// </summary>
public class ArrayModelBinder : IModelBinder
{

    /// <summary>
    /// Binds a model from a comma-seperated string in the query string to an enumerable type.
    /// </summary>
    /// <param name="bindingContext">The context for the model binding operation.</param>
    /// <returns>
    /// A completed <see cref="Task"/> representing the model binding process.
    /// The task will set the model binding result to success or failure depending on the input validity.
    /// </returns>
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        // Check if the target model type is enumerable.
        if (!bindingContext.ModelMetadata.IsEnumerableType)
        {
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }

        // Retrieve the provided value from the value provider (e.g., query string)
        var providedValue = bindingContext.ValueProvider
            .GetValue(bindingContext.ModelName)
            .ToString();

        // Check if the provided value is empty or null.
        if (string.IsNullOrEmpty(providedValue))
        {
            bindingContext.Result = ModelBindingResult.Success(null);
            return Task.CompletedTask;
        }

        // Retrieve the generic type of the enumerable (e.g., Guid, int, etc.).
        var genericType = bindingContext.ModelType
            .GetTypeInfo()
            .GenericTypeArguments[0];

        // Get a type converter for the generic type to convert string values to the target type.
        var converter = TypeDescriptor.GetConverter(genericType);

        // Split the input string, convert each value to the target type, and store in an array. 
        var objectArray = providedValue.Split([","], StringSplitOptions.RemoveEmptyEntries)
            .Select(x => converter.ConvertFromString(x.Trim()))
            .ToArray();

        // Create an array of the target type and copy the converted values into it.
        var guidArray = Array.CreateInstance(genericType, objectArray.Length);
        objectArray.CopyTo(guidArray, 0);

        // Set the bound model to the created array and mark the binding as successful.
        bindingContext.Model = guidArray;
        bindingContext.Result = ModelBindingResult.Success(bindingContext.Model);

        return Task.CompletedTask;
    }
}