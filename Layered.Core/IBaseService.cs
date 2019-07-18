using Layered.ServiceModel;
using System;
using System.Collections.Generic;

namespace Layered.Core
{
    public interface IBaseService<TViewModel> where TViewModel : class
    {
        Message<TViewModel> ReturnSuccess(TViewModel data);

        Message<IEnumerable<TViewModel>> ReturnSuccess(IEnumerable<TViewModel> data);

        Message<TViewModel> ReturnException(TViewModel data, Exception error);

        Message<TViewModel> ReturnValidationErrors(TViewModel data, List<ValidationError> errors);

    }
}
