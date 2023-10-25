using System.Text.Json;
using Ticket4me.Api.Extensions.String;

namespace Ticket4me.Api.Policies.v1;

public class JsonSnakeCasePolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
        => name.ToSnakeCase();
}
