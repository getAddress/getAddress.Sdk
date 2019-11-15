using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public class AutocompletePostcodeResponse : ResponseBase<AutocompletePostcodeResponse.Success, AutocompletePostcodeResponse.Failed>
    {

        protected AutocompletePostcodeResponse(int statusCode, string reasonPhase, string raw, bool isSuccess) : base(statusCode, reasonPhase, raw, isSuccess)
        {


        }

        public class Success : AutocompletePostcodeResponse
        {
            public IEnumerable<PostcodePrediction> Predictions { get; }

            internal Success(int statusCode, string reasonPhase, string raw, IEnumerable<PostcodePrediction> predictions) : base(statusCode, reasonPhase, raw, true)
            {
                this.SuccessfulResult = this;
                Predictions = predictions;
            }
        }

        public class Failed : AutocompletePostcodeResponse
        {
            internal Failed(int statusCode, string reasonPhase, string raw) : base(statusCode, reasonPhase, raw, false)
            {
                this.FailedResult = this;
            }
        }
    }

}
