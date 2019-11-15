using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public class AutocompleteResponse : ResponseBase<AutocompleteResponse.Success, AutocompleteResponse.Failed>
    {

        protected AutocompleteResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {


        }

        public class Success : AutocompleteResponse
        {
            public IEnumerable<Prediction> Predictions { get; }
            
            internal Success(int statusCode, string reasonPhase, string raw, IEnumerable<Prediction> predictions) : base(statusCode, reasonPhase, raw, true)
            {
                this.SuccessfulResult = this;
                Predictions = predictions;
            }
        }

        public class Failed : AutocompleteResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                this.FailedResult = this;
            }
        }
    }

}
