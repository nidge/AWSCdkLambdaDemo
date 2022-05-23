// This was developed by following the tutorial at https://www.youtube.com/watch?v=5aBf0W0_FDY
// The command cdk publish didn't work so I had to manually publish the projects (right click and publish)

using Amazon.CDK;
using Amazon.CDK.AWS.Lambda;
using Amazon.CDK.AWS.APIGateway;
using Constructs;

namespace cdk
{
    public class FooBarLambdasStack : Stack
    {
        internal FooBarLambdasStack(Amazon.CDK.Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            // The code that defines your stack goes here
            var fooLambda = new Amazon.CDK.AWS.Lambda.Function(this, "fooLambda", new FunctionProps
            {
                Runtime = Runtime.DOTNET_CORE_3_1,
                Code = Code.FromAsset("src/foolambda/bin/Debug/netcoreapp3.1/publish"),
                Handler = "FooLambda::FooLambda.Functions::Get"
            });

            new LambdaRestApi(this, "fooApiEndpoint", new LambdaRestApiProps
            {
                Handler = fooLambda
            });

            var barLambda = new Amazon.CDK.AWS.Lambda.Function(this, "barLambda", new FunctionProps
            {
                Runtime = Runtime.DOTNET_CORE_3_1,
                Code = Code.FromAsset("src/barlambda/bin/Debug/netcoreapp3.1/publish"),
                Handler = "BarLambda::BarLambda.Functions::Get"
            });

            new LambdaRestApi(this, "barApiEndpoint", new LambdaRestApiProps
            {
                Handler = barLambda
            });
        }
    }
}
