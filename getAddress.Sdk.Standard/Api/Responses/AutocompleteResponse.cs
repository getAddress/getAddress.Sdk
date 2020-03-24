using System.Collections.Generic;

namespace getAddress.Sdk.Api.Responses
{
    public class AutocompleteResponse : ResponseBase<AutocompleteResponse.Success, AutocompleteResponse.Failed, AutocompleteResponse.TokenExpired>
    {

        protected AutocompleteResponse(int statusCode, string reasonPhrase, string raw, bool isSuccess) : base(statusCode, reasonPhrase, raw, isSuccess)
        {


        }

        public class Success : AutocompleteResponse
        {
            public IEnumerable<Prediction> Predictions { get; }

            public Success(int statusCode, string reasonPhrase, string raw, IEnumerable<Prediction> predictions) : base(statusCode, reasonPhrase, raw, true)
            {
                this.SuccessfulResult = this;
                Predictions = predictions;
            }
        }

        public class Failed : AutocompleteResponse
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
                FailedResult = this;
                TokenExpiredResult = this;
            }
        }
    }

}
