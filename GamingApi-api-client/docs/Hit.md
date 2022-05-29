
# Org.OpenAPITools.Model.Hit

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Attacker** | **string** | The attacker&#39;s steamID64, must be 17 chars long. | 
**Victim** | **string** | The attacker&#39;s steamID64, must be 17 chars long. | 
**HitTimestamp** | **DateTime** |  | 
**HitDamage** | **decimal** |  | 
**HitDistance** | **decimal** |  | [optional] 
**HitAreaId** | **int** | 1&#x3D;\&quot;Head\&quot;, 2&#x3D;\&quot;Chest\&quot;, 4&#x3D;\&quot;Stomach\&quot;, 8&#x3D;\&quot;Arm\&quot;, 16&#x3D;\&quot;Hand\&quot;, 32&#x3D;\&quot;Leg\&quot;, 64&#x3D;\&quot;Foot\&quot;, -1&#x3D;\&quot;Everywhere\&quot; | 
**AttackerActiveItem** | [**HitAttackerActiveItem**](HitAttackerActiveItem.md) |  | 
**VictimActiveItem** | [**HitAttackerActiveItem**](HitAttackerActiveItem.md) |  | 
**AttackerPosition** | [**PlayerPosition**](PlayerPosition.md) |  | 
**VictimPosition** | [**PlayerPosition**](PlayerPosition.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

