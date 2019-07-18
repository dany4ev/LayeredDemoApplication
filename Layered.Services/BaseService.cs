using Layered.Core;
using Layered.ServiceModel;
using System;
using System.Collections.Generic;

namespace Layered.Services
{
    public abstract class BaseService<TViewModel> : IBaseService<TViewModel> where TViewModel : class
    {
        public Message<TViewModel> ReturnException(TViewModel data, Exception error)
        {
            var response = new Message<TViewModel>
            {
                Error = error
            };

            return response;
        }

        public Message<IEnumerable<TViewModel>> ReturnException(IEnumerable<TViewModel> data, Exception error)
        {
            Message<IEnumerable<TViewModel>> response = new Message<IEnumerable<TViewModel>>
            {
                Error = error
            };

            return response;
        }

        public Message<TViewModel> ReturnSuccess(TViewModel data)
        {
            var msg = new Message<TViewModel>
            {
                Data = data
            };

            return msg;
        }

        public Message<IEnumerable<TViewModel>> ReturnSuccess(IEnumerable<TViewModel> data)
        {
            var msg = new Message<IEnumerable<TViewModel>>
            {
                Data = data
            };

            return msg;
        }

        public Message<TViewModel> ReturnValidationErrors(TViewModel data, List<ValidationError> errors)
        {
            var msg = new Message<TViewModel>
            {
                ValidationErrors = errors
            };

            return msg;
        }
    }
}
