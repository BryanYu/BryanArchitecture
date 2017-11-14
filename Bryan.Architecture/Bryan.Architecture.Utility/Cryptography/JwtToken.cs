using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JWT;
using JWT.Algorithms;
using JWT.Serializers;

namespace Bryan.Architecture.Utility.Cryptography
{
    /// <summary>The jwt token.</summary>
    public static class JwtToken
    {
        /// <summary>The generate.</summary>
        /// <param name="secret">The secret.</param>
        /// <param name="data">The data.</param>
        /// <typeparam name="TData">TData</typeparam>
        /// <returns>The <see cref="string"/>.</returns>
        public static string Generate<TData>(string secret, TData data = null) where TData : class
        {
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var token = encoder.Encode(data, secret);
            return token;
        }

        /// <summary>The decode.</summary>
        /// <param name="secret">The secret.</param>
        /// <param name="token">The token.</param>
        /// <typeparam name="TData">TData</typeparam>
        /// <returns>The <see cref="TData"/>.</returns>
        public static TData Decode<TData>(string secret, string token)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
                var json = decoder.Decode(token, secret, true);
                var result = serializer.Deserialize<TData>(json);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}