# Org.OpenAPITools.Api.ServerApi

All URIs are relative to *https://virtserver.swaggerhub.com/jonaslagoni/RustServer/1.0.0*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetAchievementGroupsOfServer**](ServerApi.md#getachievementgroupsofserver) | **GET** /servers/{server_id}/achievements/groups | A list of all groups with subgroups and achievements for a server
[**GetAchievementsOfServer**](ServerApi.md#getachievementsofserver) | **GET** /servers/{server_id}/achievements | A list of all achievements on specific server.
[**GetCombatKillsOnWipe**](ServerApi.md#getcombatkillsonwipe) | **GET** /servers/{server_id}/wipe/{wipe_id}/combatlog/kills | Kills on a server in a wipe
[**GetHuntForWeaponsForCurrentWipe**](ServerApi.md#gethuntforweaponsforcurrentwipe) | **GET** /servers/{server_id}/huntforweapons | Hunt for weapons list of the current wipe.
[**GetHuntForWeaponsForWipe**](ServerApi.md#gethuntforweaponsforwipe) | **GET** /servers/{server_id}/wipe/{wipe_id}/huntforweapons | Hunt for weapons list for the specific server in the specific wipe.
[**GetLeaderboards**](ServerApi.md#getleaderboards) | **GET** /servers/{server_id}/leaderboards | Leaderboard stats on specific server.
[**GetLeaderboardsForWipe**](ServerApi.md#getleaderboardsforwipe) | **GET** /servers/{server_id}/wipe/{wipe_id}/leaderboards | Leaderboard stats on specific server in the specific wipe.
[**GetServer**](ServerApi.md#getserver) | **GET** /servers/{server_id} | Get basic server information
[**GetServerCombatKills**](ServerApi.md#getservercombatkills) | **GET** /servers/{server_id}/combatlog/kills | Kills on a server
[**GetServerWipes**](ServerApi.md#getserverwipes) | **GET** /servers/{server_id}/wipes | Get all wipes from a server
[**GetServers**](ServerApi.md#getservers) | **GET** /servers | Get all the servers
[**GetTitlesFromServer**](ServerApi.md#gettitlesfromserver) | **GET** /servers/{server_id}/titles | A list of all titles on specific server.



## GetAchievementGroupsOfServer

> List&lt;AchievementGroup&gt; GetAchievementGroupsOfServer (int serverId)

A list of all groups with subgroups and achievements for a server

This returns the list of groups with subgroups and their achievements for a server

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetAchievementGroupsOfServerExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://virtserver.swaggerhub.com/jonaslagoni/RustServer/1.0.0";
            // Configure API key authorization: BearerAuth
            Configuration.Default.AddApiKey("Bearer", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Bearer", "Bearer");

            var apiInstance = new ServerApi(Configuration.Default);
            var serverId = 56;  // int | The server id to retrieve the achievement groups for.

            try
            {
                // A list of all groups with subgroups and achievements for a server
                List<AchievementGroup> result = apiInstance.GetAchievementGroupsOfServer(serverId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ServerApi.GetAchievementGroupsOfServer: " + e.Message );
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
 **serverId** | **int**| The server id to retrieve the achievement groups for. | 

### Return type

[**List&lt;AchievementGroup&gt;**](AchievementGroup.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Returns the list of groups with subgroups and their achievements. |  -  |
| **400** | Bad request |  -  |
| **401** | You are not authorized to access this resource |  -  |
| **404** | The specified resource was not found |  -  |
| **500** | Internal Server Error could not process your request |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetAchievementsOfServer

> List&lt;Achievement&gt; GetAchievementsOfServer (int serverId)

A list of all achievements on specific server.

This returns all the achievements on a server

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetAchievementsOfServerExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://virtserver.swaggerhub.com/jonaslagoni/RustServer/1.0.0";
            // Configure API key authorization: BearerAuth
            Configuration.Default.AddApiKey("Bearer", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Bearer", "Bearer");

            var apiInstance = new ServerApi(Configuration.Default);
            var serverId = 56;  // int | The server id to retrieve the achievements for

            try
            {
                // A list of all achievements on specific server.
                List<Achievement> result = apiInstance.GetAchievementsOfServer(serverId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ServerApi.GetAchievementsOfServer: " + e.Message );
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

### Return type

[**List&lt;Achievement&gt;**](Achievement.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | the list of achievements the server has |  -  |
| **400** | Bad request |  -  |
| **401** | You are not authorized to access this resource |  -  |
| **500** | Internal Server Error could not process your request |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetCombatKillsOnWipe

> List&lt;CombatKill&gt; GetCombatKillsOnWipe (int serverId, int wipeId, int? offset = null, int? limit = null)

Kills on a server in a wipe

This returns all the kills on a specific server in the specific wipe

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetCombatKillsOnWipeExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://virtserver.swaggerhub.com/jonaslagoni/RustServer/1.0.0";
            // Configure API key authorization: BearerAuth
            Configuration.Default.AddApiKey("Bearer", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Bearer", "Bearer");

            var apiInstance = new ServerApi(Configuration.Default);
            var serverId = 56;  // int | The server id to retrieve the kills on
            var wipeId = 56;  // int | The wipe id to retrieve the kills on
            var offset = 56;  // int? | The number of items to skip before starting to collect the result set. (optional) 
            var limit = 56;  // int? | The numbers of items to return. (optional) 

            try
            {
                // Kills on a server in a wipe
                List<CombatKill> result = apiInstance.GetCombatKillsOnWipe(serverId, wipeId, offset, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ServerApi.GetCombatKillsOnWipe: " + e.Message );
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
| **200** | the list of kills on a server, listed as newest first. |  -  |
| **400** | Bad request |  -  |
| **401** | You are not authorized to access this resource |  -  |
| **500** | Internal Server Error could not process your request |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetHuntForWeaponsForCurrentWipe

> List&lt;HuntForWeapon&gt; GetHuntForWeaponsForCurrentWipe (int serverId, int? offset = null, int? limit = null)

Hunt for weapons list of the current wipe.

This returns a list of all the hunt for weapons items for this wipe and if any of them has been found and by who.. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetHuntForWeaponsForCurrentWipeExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://virtserver.swaggerhub.com/jonaslagoni/RustServer/1.0.0";
            // Configure API key authorization: BearerAuth
            Configuration.Default.AddApiKey("Bearer", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Bearer", "Bearer");

            var apiInstance = new ServerApi(Configuration.Default);
            var serverId = 56;  // int | The server id to retrieve the hunt for weapons for.
            var offset = 56;  // int? | The number of items to skip before starting to collect the result set. (optional) 
            var limit = 56;  // int? | The numbers of items to return. (optional) 

            try
            {
                // Hunt for weapons list of the current wipe.
                List<HuntForWeapon> result = apiInstance.GetHuntForWeaponsForCurrentWipe(serverId, offset, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ServerApi.GetHuntForWeaponsForCurrentWipe: " + e.Message );
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
 **serverId** | **int**| The server id to retrieve the hunt for weapons for. | 
 **offset** | **int?**| The number of items to skip before starting to collect the result set. | [optional] 
 **limit** | **int?**| The numbers of items to return. | [optional] 

### Return type

[**List&lt;HuntForWeapon&gt;**](HuntForWeapon.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The list of hunt for weapons items |  -  |
| **400** | Bad request |  -  |
| **401** | You are not authorized to access this resource |  -  |
| **404** | The specified resource was not found |  -  |
| **500** | Internal Server Error could not process your request |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetHuntForWeaponsForWipe

> List&lt;HuntForWeapon&gt; GetHuntForWeaponsForWipe (int serverId, int wipeId, int? offset = null, int? limit = null)

Hunt for weapons list for the specific server in the specific wipe.

This returns a list of all the hunt for weapons items for the specific wipe and if any of them has been found and by who.. 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetHuntForWeaponsForWipeExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://virtserver.swaggerhub.com/jonaslagoni/RustServer/1.0.0";
            // Configure API key authorization: BearerAuth
            Configuration.Default.AddApiKey("Bearer", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Bearer", "Bearer");

            var apiInstance = new ServerApi(Configuration.Default);
            var serverId = 56;  // int | The server id to retrieve the hunt for weapons for.
            var wipeId = 56;  // int | The wipe id to retrieve the hunt for weapons for.
            var offset = 56;  // int? | The number of items to skip before starting to collect the result set. (optional) 
            var limit = 56;  // int? | The numbers of items to return. (optional) 

            try
            {
                // Hunt for weapons list for the specific server in the specific wipe.
                List<HuntForWeapon> result = apiInstance.GetHuntForWeaponsForWipe(serverId, wipeId, offset, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ServerApi.GetHuntForWeaponsForWipe: " + e.Message );
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
 **serverId** | **int**| The server id to retrieve the hunt for weapons for. | 
 **wipeId** | **int**| The wipe id to retrieve the hunt for weapons for. | 
 **offset** | **int?**| The number of items to skip before starting to collect the result set. | [optional] 
 **limit** | **int?**| The numbers of items to return. | [optional] 

### Return type

[**List&lt;HuntForWeapon&gt;**](HuntForWeapon.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The list of hunt for weapons items |  -  |
| **400** | Bad request |  -  |
| **401** | You are not authorized to access this resource |  -  |
| **404** | The specified resource was not found |  -  |
| **500** | Internal Server Error could not process your request |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetLeaderboards

> List&lt;LeaderBoardPlayer&gt; GetLeaderboards (int serverId, int? offset = null, int? limit = null)

Leaderboard stats on specific server.

This returns a list of players on the leaderboard 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetLeaderboardsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://virtserver.swaggerhub.com/jonaslagoni/RustServer/1.0.0";
            // Configure API key authorization: BearerAuth
            Configuration.Default.AddApiKey("Bearer", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Bearer", "Bearer");

            var apiInstance = new ServerApi(Configuration.Default);
            var serverId = 56;  // int | The server id to retrieve the leaderboard for
            var offset = 56;  // int? | The number of items to skip before starting to collect the result set. (optional) 
            var limit = 56;  // int? | The numbers of items to return. (optional) 

            try
            {
                // Leaderboard stats on specific server.
                List<LeaderBoardPlayer> result = apiInstance.GetLeaderboards(serverId, offset, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ServerApi.GetLeaderboards: " + e.Message );
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
 **offset** | **int?**| The number of items to skip before starting to collect the result set. | [optional] 
 **limit** | **int?**| The numbers of items to return. | [optional] 

### Return type

[**List&lt;LeaderBoardPlayer&gt;**](LeaderBoardPlayer.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The list of leaderboard players |  -  |
| **400** | Bad request |  -  |
| **401** | You are not authorized to access this resource |  -  |
| **404** | The specified resource was not found |  -  |
| **500** | Internal Server Error could not process your request |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetLeaderboardsForWipe

> List&lt;LeaderBoardPlayer&gt; GetLeaderboardsForWipe (int serverId, int wipeId, int? offset = null, int? limit = null)

Leaderboard stats on specific server in the specific wipe.

This returns a list of players on the leaderboard 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetLeaderboardsForWipeExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://virtserver.swaggerhub.com/jonaslagoni/RustServer/1.0.0";
            // Configure API key authorization: BearerAuth
            Configuration.Default.AddApiKey("Bearer", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Bearer", "Bearer");

            var apiInstance = new ServerApi(Configuration.Default);
            var serverId = 56;  // int | The server id to retrieve the leaderboard for
            var wipeId = 56;  // int | The wipe id to retrieve the leaderboard for
            var offset = 56;  // int? | The number of items to skip before starting to collect the result set. (optional) 
            var limit = 56;  // int? | The numbers of items to return. (optional) 

            try
            {
                // Leaderboard stats on specific server in the specific wipe.
                List<LeaderBoardPlayer> result = apiInstance.GetLeaderboardsForWipe(serverId, wipeId, offset, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ServerApi.GetLeaderboardsForWipe: " + e.Message );
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
 **wipeId** | **int**| The wipe id to retrieve the leaderboard for | 
 **offset** | **int?**| The number of items to skip before starting to collect the result set. | [optional] 
 **limit** | **int?**| The numbers of items to return. | [optional] 

### Return type

[**List&lt;LeaderBoardPlayer&gt;**](LeaderBoardPlayer.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The list of leaderboard players |  -  |
| **400** | Bad request |  -  |
| **401** | You are not authorized to access this resource |  -  |
| **404** | The specified resource was not found |  -  |
| **500** | Internal Server Error could not process your request |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetServer

> Server GetServer (int serverId)

Get basic server information

This returns basic information about a specific server 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetServerExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://virtserver.swaggerhub.com/jonaslagoni/RustServer/1.0.0";
            // Configure API key authorization: BearerAuth
            Configuration.Default.AddApiKey("Bearer", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Bearer", "Bearer");

            var apiInstance = new ServerApi(Configuration.Default);
            var serverId = 56;  // int | The server id to retrieve the basic information about

            try
            {
                // Get basic server information
                Server result = apiInstance.GetServer(serverId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ServerApi.GetServer: " + e.Message );
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
 **serverId** | **int**| The server id to retrieve the basic information about | 

### Return type

[**Server**](Server.md)

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
| **500** | Internal Server Error could not process your request |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetServerCombatKills

> List&lt;CombatKill&gt; GetServerCombatKills (int serverId, int? offset = null, int? limit = null)

Kills on a server

This returns all the kills on a specific server

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetServerCombatKillsExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://virtserver.swaggerhub.com/jonaslagoni/RustServer/1.0.0";
            // Configure API key authorization: BearerAuth
            Configuration.Default.AddApiKey("Bearer", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Bearer", "Bearer");

            var apiInstance = new ServerApi(Configuration.Default);
            var serverId = 56;  // int | The server id to retrieve the kills on
            var offset = 56;  // int? | The number of items to skip before starting to collect the result set. (optional) 
            var limit = 56;  // int? | The numbers of items to return. (optional) 

            try
            {
                // Kills on a server
                List<CombatKill> result = apiInstance.GetServerCombatKills(serverId, offset, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ServerApi.GetServerCombatKills: " + e.Message );
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
| **200** | the list of kills on a server, listed as newest first. |  -  |
| **400** | Bad request |  -  |
| **401** | You are not authorized to access this resource |  -  |
| **500** | Internal Server Error could not process your request |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetServerWipes

> List&lt;Wipe&gt; GetServerWipes (int serverId, int? offset = null, int? limit = null)

Get all wipes from a server

This returns all the wipes on the server 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetServerWipesExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://virtserver.swaggerhub.com/jonaslagoni/RustServer/1.0.0";
            // Configure API key authorization: BearerAuth
            Configuration.Default.AddApiKey("Bearer", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Bearer", "Bearer");

            var apiInstance = new ServerApi(Configuration.Default);
            var serverId = 56;  // int | The server id to retrieve the wipes from
            var offset = 56;  // int? | The number of items to skip before starting to collect the result set. (optional) 
            var limit = 56;  // int? | The numbers of items to return. (optional) 

            try
            {
                // Get all wipes from a server
                List<Wipe> result = apiInstance.GetServerWipes(serverId, offset, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ServerApi.GetServerWipes: " + e.Message );
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
 **serverId** | **int**| The server id to retrieve the wipes from | 
 **offset** | **int?**| The number of items to skip before starting to collect the result set. | [optional] 
 **limit** | **int?**| The numbers of items to return. | [optional] 

### Return type

[**List&lt;Wipe&gt;**](Wipe.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The wipes |  -  |
| **400** | Bad request |  -  |
| **401** | You are not authorized to access this resource |  -  |
| **500** | Internal Server Error could not process your request |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetServers

> List&lt;Server&gt; GetServers ()

Get all the servers

This returns basic information about all the servers 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetServersExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://virtserver.swaggerhub.com/jonaslagoni/RustServer/1.0.0";
            // Configure API key authorization: BearerAuth
            Configuration.Default.AddApiKey("Bearer", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Bearer", "Bearer");

            var apiInstance = new ServerApi(Configuration.Default);

            try
            {
                // Get all the servers
                List<Server> result = apiInstance.GetServers();
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ServerApi.GetServers: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

This endpoint does not need any parameter.

### Return type

[**List&lt;Server&gt;**](Server.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | the basic information about all the servers |  -  |
| **400** | Bad request |  -  |
| **401** | You are not authorized to access this resource |  -  |
| **500** | Internal Server Error could not process your request |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


## GetTitlesFromServer

> List&lt;Title&gt; GetTitlesFromServer (int serverId)

A list of all titles on specific server.

This returns all the titles on a server

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetTitlesFromServerExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://virtserver.swaggerhub.com/jonaslagoni/RustServer/1.0.0";
            // Configure API key authorization: BearerAuth
            Configuration.Default.AddApiKey("Bearer", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("Bearer", "Bearer");

            var apiInstance = new ServerApi(Configuration.Default);
            var serverId = 56;  // int | The server id to retrieve the titles for

            try
            {
                // A list of all titles on specific server.
                List<Title> result = apiInstance.GetTitlesFromServer(serverId);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ServerApi.GetTitlesFromServer: " + e.Message );
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
 **serverId** | **int**| The server id to retrieve the titles for | 

### Return type

[**List&lt;Title&gt;**](Title.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | the list of titles on the server |  -  |
| **400** | Bad request |  -  |
| **401** | You are not authorized to access this resource |  -  |
| **500** | Internal Server Error could not process your request |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

