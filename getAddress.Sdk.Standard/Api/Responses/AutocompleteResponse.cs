using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public class AutocompleteResponse : ResponseBase<AutocompleteResponse.Success, AutocompleteResponse.Failed>
    {

        protected AutocompleteResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {


        }

        public class Success : AutocompleteResponse
        {
            public IEnumerable<Prediction> Predictions { get; }
            
            internal Success(int statusCode, string reasonPhrase, string raw, IEnumerable<Prediction> predictions) : base(statusCode, reasonPhrase, raw, true)
            {
                this.SuccessfulResult = this;
                Predictions = predictions;
            }
        }

        public class Failed : AutocompleteResponse
        {
            internal Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                this.FailedResult = this;
            }
        }
    }

}
