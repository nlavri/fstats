using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FStats.Infra
{
    public class FlagsEnumBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            var result = value.Values.Count > 0 ? Enum.Parse(bindingContext.ModelType, value.Values) : Activator.CreateInstance(bindingContext.ModelType);

            bindingContext.Result = ModelBindingResult.Success(result);
            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, value);
            return Task.CompletedTask;
        }
    }

    public class FlagsEnumBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (context.Metadata.IsFlagsEnum)
                return new FlagsEnumBinder();

            return null;
        }
    }
}
