﻿using System.Text.Json.Serialization;

namespace FruitsManagementAPI.Settings
{
    public class FirebaseSettings
    {
        [JsonPropertyName("type")]
        public string Type => "service_account";

        [JsonPropertyName("project_id")]
        public string ProjectId => "fruitsmanagement";

        [JsonPropertyName("private_key_id")]
        public string PrivateKeyId => "0ca6c3add79af610b6dac4227252aff5e2e96067";

        [JsonPropertyName("private_key")]
        public string PrivateKey => "-----BEGIN PRIVATE KEY-----\nMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQChF+3eYL7pNF3u\nwN5pR83TBEbDXhS6RGGgLnlK+wGJVQWnoMm0j2oFQU/yC3CC07NmelNIccdbrsab\nDgyw/GVz2m1RBpZOOz6oUypGepOgYFCt0QWSJM1L6uucbeFYU5j1wQ9CQDRqO1PV\nktLu/zL6ZZ4NwLMRghsYK+dQLgNPLVvK7Kv1QfGSqe6lxF6VnrQIZ9JJNLuP1vRb\nwz1VlGf8nYt4uSazZ6SezmHqDFCLUZ4KZOhAJUwqlNWoL3uy+G2AbWnLE0/fe2pl\nlv87GdNtur7KrKelT6+7Q2mrAjSWex5ZVetdKY1GDOaSFLoCokx3g+Ol4pjLIjQ9\n1Kx0PyFBAgMBAAECggEAJBfD7ESZ0Y8xkoo06rqzQ1mcby5Xj4o9o1F2TJXjeL0L\naMzOFH3jX60L9+uXOECtW8MBgOQ5KfIFPn1N26OZKXVhc7t5lqqQdc84VBUnmVGr\nEd6YlG9Zbe6C/ofh6tPEHB+2xv2yoLCNLndYekLETbTRzjwEAuK3JlnD2EOO60Cf\n3Mja+KqC/v7Q02zzg0FGbYhZgVeExwZwOTIjMPU0cWRn34tGR14SaNhApErTrc+v\neXzct+gLOPci2RTLbT5K3RuKYisQn7ExIyyW6gwyqdL6xNPtd6rZi5/T6NLca+FI\neYU4QpFd2OA7A8FU0nSKeBQnsWj1otdlNr42F2P8xwKBgQDQ38x9htoVFikFkAS6\ner8Lh4iW2aqLXrLhrYg4SRJUqXhFuXaGPA2y29Xx+LywTxMkpkhcDODtFTd3vHo6\nCXR02LIQpt9efe1qKZCB+ymABCc9FsKLn3HgFdoeAnKxxd3VkMEaYBMSCSBc2otp\n85hBwL1j33q6gamZMD2f8ZvnKwKBgQDFcGZ0nRZDy2gl2UxY952zPxYvZwx7sQLA\nUUfe9iH4JsBN7vnbsFjyHtbDQLVdm1oPMby9xUtO4L20ZGnekoP6aLvanYfeHsHq\nS6JPEm7EIFTLAniYxinxq4qw2Ikko1eQ7lmPaY34cJt4ImvmOeMRefqfpybT9eOw\nCHunRCRjQwKBgQCOzVM7RuT2oa3uFaaF78GJmmHx8GK+4kGeNUv6X0rfAvYthTzZ\nTVl4PQAqbIpkZ8uItP6noE5vCKBhhkRyRWCPOk+TPuNb8PBOMpiPpS2cTjqdc2AS\noTHzqDz1Y2sSy1p81niPFbw0CnVLxkama1pfKezRyUpZFKjlCKw5G7Ag/QKBgG6i\n0Ya/D97leHLdFT81YhUzYMcnQ4N8aUJDSbbSza40aMZDB5fndbAXP9khxX+ysgCZ\nql3c1JparXMMYZbrGzGSxtF2PNBnA9q6jzUn6xHT3C/2LoXNZWua6Ji4fgEd1s/M\nADuwtnFlCHmFMFlOTsNYSuxzyfo0a2YVGtVcBdfpAoGBAK2pWYRXnCU9J244k0Cu\ns3RAdgRq+1QAGtxrDHiBw8Uk9Z8GbAzL+muZ29C9EyH3jNyk5JdYC+1df1sXa3rG\neri1J1KW69Sr2ilkSUCSu1JONpSQoIL+DB7/Rs7T3RcRLLvdbgRQC5ySCjJYJrGj\nsYpx1P267SeK8Gl76l4zhJgz\n-----END PRIVATE KEY-----\n";

        [JsonPropertyName("client_email")]
        public string ClientEmail => "firebase-adminsdk-vkhwd@fruitsmanagement.iam.gserviceaccount.com";

        [JsonPropertyName("client_id")]
        public string ClientId => "117005204520158364956";

        [JsonPropertyName("auth_uri")]
        public string AuthUri => "https://accounts.google.com/o/oauth2/auth";

         [JsonPropertyName("token_uri")]
        public string TokenUri => "https://oauth2.googleapis.com/token";

        [JsonPropertyName("auth_provider_x509_cert_url")]
        public string AuthCertUrl => "https://www.googleapis.com/oauth2/v1/certs";

        [JsonPropertyName("client_x509_cert_url")]
        public string ClientCertUrl => "https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-vkhwd%40fruitsmanagement.iam.gserviceaccount.com";

        [JsonPropertyName("universe_domain")]
        public string UniverseDomain => "googleapis.com";


    }
}
