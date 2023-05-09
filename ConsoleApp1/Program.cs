
using System;

string testString = "Check";
using (HttpResponseMessage response = client.GetAsync("localhost:10000/foo").Result)
{
    response.EnsureSuccessStatusCode();
    string responseBody = await response.Content.ReadAsStringAsync();
    string sss = responseBody.ToString();

    JToken token = JObject.Parse(sss);
    int count = (int)token.SelectToken("count");
    Assert(count, 1);

    if (count > 0)
    {
        string bar = (string)token.SelectToken($"value[{0}].bar");
        Assert(bar, testString);
    }
}
