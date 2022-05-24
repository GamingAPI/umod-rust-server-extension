# Org.OpenAPITools.Api.PlayerApi

All URIs are relative to *https://virtserver.swaggerhub.com/jonaslagoni/RustServer/1.0.0*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetAchievementGroupsForPlayerOnServer**](PlayerApi.md#getachievementgroupsforplayeronserver) | **GET** /servers/{server_id}/player/{steam_id}/achievements/groups | A list of the player&#39;s achievements devided into groups.
[**GetAchievementsOfPlayer**](PlayerApi.md#getachievementsofplayer) | **GET** /servers/{server_id}/player/{steam_id}/achievements | A list of players obtained achievements.
[**GetPlayerCombatDeaths**](PlayerApi.md#getplayercombatdeaths) | **GET** /servers/{server_id}/player/{steam_id}/combatlog/deaths | A players deaths on a server
[**GetPlayerCombatDeathsOnWipe**](PlayerApi.md#getplayercombatdeathsonwipe) | **GET** /servers/{server_id}/wipe/{wipe_id}/player/{steam_id}/combatlog/deaths | A players deaths on a server
[**GetPlayerCombatKills**](PlayerApi.md#getplayercombatkills) | **GET** /servers/{server_id}/player/{steam_id}/combatlog/kills | A players kills on a server
[**GetPlayerCombatKillsInWipe**](PlayerApi.md#getplayercombatkillsinwipe) | **GET** /servers/{server_id}/wipe/{wipe_id}/player/{steam_id}/combatlog/kills | A players kills on a server
[**GetRankOfPlayer**](PlayerApi.md#getrankofplayer) | **GET** /servers/{server_id}/player/{steam_id}/rank | Rank stats on specific player on a specific server.
[**GetRankOfPlayerOnWipe**](PlayerApi.md#getrankofplayeronwipe) | **GET** /servers/{server_id}/wipe/{wipe_id}/player/{steam_id}/rank | Rank stats on specific player on a specific server on a specific wipe.
[**GetTitlesOfPlayer**](PlayerApi.md#gettitlesofplayer) | **GET** /servers/{server_id}/player/{steam_id}/titles | A list of titles for the player.



## GetAchievementGroupsForPlayerOnServer

> List&lt;PlayerAchievementGroup&gt; GetAchievementGroupsForPlayerOnServer (int serverId, string steamId)

A list of the player's achievements devided into groups.

A list of the player's achievements devided into groups.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetAchievementGroupsForPlayerOnServerExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://virtserver.swaggerhub.com/jonaslagoni/RustServer/1.0.0";
            // Configure API key authorization: BearerAuth
            Configuration.Default.AddApiKey("Bearer", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Bearer", "Bearer");

            var apiInstance = new PlayerApi(Configuration.Default);
            var serverId = 56;  // int | The server id to retrieve the achievement groups for
            var steamId = steamId_example;  // string | The player's steamID64 to find the obtained achievements for, must be 17 chars long.

            try
            {
                // A list of the player's achievements devided into groups.
                List<PlayerAchievementGroup> result = apiInstance.GetAchievementGroupsForPlayerOnServer(serverId, steamId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling PlayerApi.GetAchievementGroupsForPlayerOnServer: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **serverId** | **int**| The server id to retrieve the achievement groups for | 
 **steamId** | **string**| The player&#39;s steamID64 to find the obtained achievements for, must be 17 chars long. | 

### Return type

[**List&lt;PlayerAchievementGroup&gt;**](PlayerAchievementGroup.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The list of player achievements divided into groups. |  -  |
| **400** | Bad request |  -  |
| **401** | You are not authorized to access this resource |  -  |
| **404** | Player does not exist, does not have any achievements, or no achievement groups on the server. |  -  |
| **500** | Internal Server Error could not process your request |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetAchievementsOfPlayer

> List&lt;PlayerAchievement&gt; GetAchievementsOfPlayer (int serverId, string steamId)

A list of players obtained achievements.

This returns all the players obtained achievements

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetAchievementsOfPlayerExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://virtserver.swaggerhub.com/jonaslagoni/RustServer/1.0.0";
            // Configure API key authorization: BearerAuth
            Configuration.Default.AddApiKey("Bearer", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Bearer", "Bearer");

            var apiInstance = new PlayerApi(Configuration.Default);
            var serverId = 56;  // int | The server id to retrieve the achievements for
            var steamId = steamId_example;  // string | The player's steamID64 to find the obtained achievements for, must be 17 chars long.

            try
            {
                // A list of players obtained achievements.
                List<PlayerAchievement> result = apiInstance.GetAchievementsOfPlayer(serverId, steamId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling PlayerApi.GetAchievementsOfPlayer: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **serverId** | **int**| The server id to retrieve the achievements for | 
 **steamId** | **string**| The player&#39;s steamID64 to find the obtained achievements for, must be 17 chars long. | 

### Return type

[**List&lt;PlayerAchievement&gt;**](PlayerAchievement.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | the list of achievements the player has obtained |  -  |
| **400** | Bad request |  -  |
| **401** | You are not authorized to access this resource |  -  |
| **404** | The specified resource was not found |  -  |
| **500** | Internal Server Error could not process your request |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetPlayerCombatDeaths

> List&lt;CombatKill&gt; GetPlayerCombatDeaths (int serverId, string steamId, int? offset = null, int? limit = null)

A players deaths on a server

This returns all the players deaths on a specific server

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetPlayerCombatDeathsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://virtserver.swaggerhub.com/jonaslagoni/RustServer/1.0.0";
            // Configure API key authorization: BearerAuth
            Configuration.Default.AddApiKey("Bearer", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Bearer", "Bearer");

            var apiInstance = new PlayerApi(Configuration.Default);
            var serverId = 56;  // int | The server id to retrieve the deaths on
            var steamId = steamId_example;  // string | The player's steamID64 to find the deaths for, must be 17 chars long.
            var offset = 56;  // int? | The number of items to skip before starting to collect the result set. (optional) 
            var limit = 56;  // int? | The numbers of items to return. (optional) 

            try
            {
                // A players deaths on a server
                List<CombatKill> result = apiInstance.GetPlayerCombatDeaths(serverId, steamId, offset, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling PlayerApi.GetPlayerCombatDeaths: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **serverId** | **int**| The server id to retrieve the deaths on | 
 **steamId** | **string**| The player&#39;s steamID64 to find the deaths for, must be 17 chars long. | 
 **offset** | **int?**| The number of items to skip before starting to collect the result set. | [optional] 
 **limit** | **int?**| The numbers of items to return. | [optional] 

### Return type

[**List&lt;CombatKill&gt;**](CombatKill.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | the list of deaths for a player listed as newest first. |  -  |
| **400** | Bad request |  -  |
| **401** | You are not authorized to access this resource |  -  |
| **500** | Internal Server Error could not process your request |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetPlayerCombatDeathsOnWipe

> List&lt;CombatKill&gt; GetPlayerCombatDeathsOnWipe (int serverId, int wipeId, string steamId, int? offset = null, int? limit = null)

A players deaths on a server

This returns all the players deaths on a specific server in the specific wipe

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetPlayerCombatDeathsOnWipeExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://virtserver.swaggerhub.com/jonaslagoni/RustServer/1.0.0";
            // Configure API key authorization: BearerAuth
            Configuration.Default.AddApiKey("Bearer", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Bearer", "Bearer");

            var apiInstance = new PlayerApi(Configuration.Default);
            var serverId = 56;  // int | The server id to retrieve the deaths on
            var wipeId = 56;  // int | The wipe id to retrieve the deaths on
            var steamId = steamId_example;  // string | The player's steamID64 to find the deaths for, must be 17 chars long.
            var offset = 56;  // int? | The number of items to skip before starting to collect the result set. (optional) 
            var limit = 56;  // int? | The numbers of items to return. (optional) 

            try
            {
                // A players deaths on a server
                List<CombatKill> result = apiInstance.GetPlayerCombatDeathsOnWipe(serverId, wipeId, steamId, offset, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling PlayerApi.GetPlayerCombatDeathsOnWipe: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **serverId** | **int**| The server id to retrieve the deaths on | 
 **wipeId** | **int**| The wipe id to retrieve the deaths on | 
 **steamId** | **string**| The player&#39;s steamID64 to find the deaths for, must be 17 chars long. | 
 **offset** | **int?**| The number of items to skip before starting to collect the result set. | [optional] 
 **limit** | **int?**| The numbers of items to return. | [optional] 

### Return type

[**List&lt;CombatKill&gt;**](CombatKill.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | the list of deaths for a player listed as newest first. |  -  |
| **400** | Bad request |  -  |
| **401** | You are not authorized to access this resource |  -  |
| **500** | Internal Server Error could not process your request |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetPlayerCombatKills

> List&lt;CombatKill&gt; GetPlayerCombatKills (int serverId, string steamId, int? offset = null, int? limit = null)

A players kills on a server

This returns all the players kills on a specific server

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetPlayerCombatKillsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://virtserver.swaggerhub.com/jonaslagoni/RustServer/1.0.0";
            // Configure API key authorization: BearerAuth
            Configuration.Default.AddApiKey("Bearer", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Bearer", "Bearer");

            var apiInstance = new PlayerApi(Configuration.Default);
            var serverId = 56;  // int | The server id to retrieve the kills on
            var steamId = steamId_example;  // string | The player's steamID64 to find the obtained kills for, must be 17 chars long.
            var offset = 56;  // int? | The number of items to skip before starting to collect the result set. (optional) 
            var limit = 56;  // int? | The numbers of items to return. (optional) 

            try
            {
                // A players kills on a server
                List<CombatKill> result = apiInstance.GetPlayerCombatKills(serverId, steamId, offset, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling PlayerApi.GetPlayerCombatKills: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **serverId** | **int**| The server id to retrieve the kills on | 
 **steamId** | **string**| The player&#39;s steamID64 to find the obtained kills for, must be 17 chars long. | 
 **offset** | **int?**| The number of items to skip before starting to collect the result set. | [optional] 
 **limit** | **int?**| The numbers of items to return. | [optional] 

### Return type

[**List&lt;CombatKill&gt;**](CombatKill.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | the list of kills for a player listed as newest first. |  -  |
| **400** | Bad request |  -  |
| **401** | You are not authorized to access this resource |  -  |
| **500** | Internal Server Error could not process your request |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetPlayerCombatKillsInWipe

> List&lt;CombatKill&gt; GetPlayerCombatKillsInWipe (int serverId, int wipeId, string steamId, int? offset = null, int? limit = null)

A players kills on a server

This returns all the players kills on a specific server

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetPlayerCombatKillsInWipeExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://virtserver.swaggerhub.com/jonaslagoni/RustServer/1.0.0";
            // Configure API key authorization: BearerAuth
            Configuration.Default.AddApiKey("Bearer", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Bearer", "Bearer");

            var apiInstance = new PlayerApi(Configuration.Default);
            var serverId = 56;  // int | The server id to retrieve the kills on
            var wipeId = 56;  // int | The wipe id to retrieve the kills on
            var steamId = steamId_example;  // string | The player's steamID64 to find the obtained kills for, must be 17 chars long.
            var offset = 56;  // int? | The number of items to skip before starting to collect the result set. (optional) 
            var limit = 56;  // int? | The numbers of items to return. (optional) 

            try
            {
                // A players kills on a server
                List<CombatKill> result = apiInstance.GetPlayerCombatKillsInWipe(serverId, wipeId, steamId, offset, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling PlayerApi.GetPlayerCombatKillsInWipe: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **serverId** | **int**| The server id to retrieve the kills on | 
 **wipeId** | **int**| The wipe id to retrieve the kills on | 
 **steamId** | **string**| The player&#39;s steamID64 to find the obtained kills for, must be 17 chars long. | 
 **offset** | **int?**| The number of items to skip before starting to collect the result set. | [optional] 
 **limit** | **int?**| The numbers of items to return. | [optional] 

### Return type

[**List&lt;CombatKill&gt;**](CombatKill.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | the list of kills for a player listed as newest first. |  -  |
| **400** | Bad request |  -  |
| **401** | You are not authorized to access this resource |  -  |
| **500** | Internal Server Error could not process your request |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetRankOfPlayer

> RankPlayer GetRankOfPlayer (int serverId, string steamId)

Rank stats on specific player on a specific server.

This returns the rank of the specific player on the specific server.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetRankOfPlayerExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://virtserver.swaggerhub.com/jonaslagoni/RustServer/1.0.0";
            // Configure API key authorization: BearerAuth
            Configuration.Default.AddApiKey("Bearer", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Bearer", "Bearer");

            var apiInstance = new PlayerApi(Configuration.Default);
            var serverId = 56;  // int | The server id to retrieve the leaderboard for
            var steamId = steamId_example;  // string | The player's steamID64 to find the obtained achievements for, must be 17 chars long.

            try
            {
                // Rank stats on specific player on a specific server.
                RankPlayer result = apiInstance.GetRankOfPlayer(serverId, steamId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling PlayerApi.GetRankOfPlayer: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **serverId** | **int**| The server id to retrieve the leaderboard for | 
 **steamId** | **string**| The player&#39;s steamID64 to find the obtained achievements for, must be 17 chars long. | 

### Return type

[**RankPlayer**](RankPlayer.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | the basic information about the server |  -  |
| **400** | Bad request |  -  |
| **401** | You are not authorized to access this resource |  -  |
| **404** | The specified resource was not found |  -  |
| **500** | Internal Server Error could not process your request |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetRankOfPlayerOnWipe

> RankPlayer GetRankOfPlayerOnWipe (int serverId, int wipeId, string steamId)

Rank stats on specific player on a specific server on a specific wipe.

This returns the rank of the specific player on the specific server in a specific wipe.

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetRankOfPlayerOnWipeExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://virtserver.swaggerhub.com/jonaslagoni/RustServer/1.0.0";
            // Configure API key authorization: BearerAuth
            Configuration.Default.AddApiKey("Bearer", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Bearer", "Bearer");

            var apiInstance = new PlayerApi(Configuration.Default);
            var serverId = 56;  // int | The server id to retrieve the leaderboard for
            var wipeId = 56;  // int | The server id to retrieve the leaderboard for
            var steamId = steamId_example;  // string | The player's steamID64, must be 17 chars long.

            try
            {
                // Rank stats on specific player on a specific server on a specific wipe.
                RankPlayer result = apiInstance.GetRankOfPlayerOnWipe(serverId, wipeId, steamId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling PlayerApi.GetRankOfPlayerOnWipe: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **serverId** | **int**| The server id to retrieve the leaderboard for | 
 **wipeId** | **int**| The server id to retrieve the leaderboard for | 
 **steamId** | **string**| The player&#39;s steamID64, must be 17 chars long. | 

### Return type

[**RankPlayer**](RankPlayer.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The rank of the player on the specific server in the specific wipe. |  -  |
| **400** | Bad request |  -  |
| **401** | You are not authorized to access this resource |  -  |
| **404** | The specified resource was not found |  -  |
| **500** | Internal Server Error could not process your request |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetTitlesOfPlayer

> List&lt;PlayerTitle&gt; GetTitlesOfPlayer (int serverId, string steamId)

A list of titles for the player.

This returns all the players titles

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetTitlesOfPlayerExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://virtserver.swaggerhub.com/jonaslagoni/RustServer/1.0.0";
            // Configure API key authorization: BearerAuth
            Configuration.Default.AddApiKey("Bearer", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Bearer", "Bearer");

            var apiInstance = new PlayerApi(Configuration.Default);
            var serverId = 56;  // int | The server id to retrieve the leaderboard for
            var steamId = steamId_example;  // string | The player's steamID64 to find the obtained achievements for, must be 17 chars long.

            try
            {
                // A list of titles for the player.
                List<PlayerTitle> result = apiInstance.GetTitlesOfPlayer(serverId, steamId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling PlayerApi.GetTitlesOfPlayer: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **serverId** | **int**| The server id to retrieve the leaderboard for | 
 **steamId** | **string**| The player&#39;s steamID64 to find the obtained achievements for, must be 17 chars long. | 

### Return type

[**List&lt;PlayerTitle&gt;**](PlayerTitle.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | the list of titles the player owns |  -  |
| **400** | Bad request |  -  |
| **401** | You are not authorized to access this resource |  -  |
| **500** | Internal Server Error could not process your request |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

