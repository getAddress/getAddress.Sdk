using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public class AutocompletePostcodeResponse : ResponseBase<AutocompletePostcodeResponse.Success, 
        AutocompletePostcodeResponse.Failed,AutocompletePostcodeResponse.TokenExpired>
    {

        protected AutocompletePostcodeResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {


        }

        public class Success : AutocompletePostcodeResponse
        {
            public IEnumerable<PostcodePrediction> Predictions { get; }

            public Success(int statusCode, string reasonPhrase, string raw, IEnumerable<PostcodePrediction> predictions) : base(statusCode, reasonPhrase, raw, true)
            {
                this.SuccessfulResult = this;
                Predictions = predictions;
            }
        }

        public class Failed : AutocompletePostcodeResponse
        {
            public Failed(int statusCode, string reasonPhrase, string raw) : base(statusCode, reasonPhrase, raw, false)
            {
                this.FailedResult = this;
            }
        }

        public class TokenExpired : Failed
        {
            public TokenExpired(string reasonPhrase, string raw) : base(401, reasonPhrase, raw)
            {
                TokenExpiredResult = this;
                IsTokenExpired = true;
            }
        }
    }

}
