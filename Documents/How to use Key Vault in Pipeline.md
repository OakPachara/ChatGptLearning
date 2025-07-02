
https://learn.microsoft.com/en-us/azure/devops/pipelines/release/azure-key-vault?view=azure-devops&tabs=serviceprincipal%2Cyaml
## Use Managed Identity approach

1. Create new **Managed Identity approach**

2. In **Key Vault** (Access by using Azure RBAC )
   IAM > Add role assignment > Role:Key Vault Secrets User > Managed Identity > Select members: Choose Managed Identity from No.1
	
3. Go to Azure devops
  Create service Connection > Azure Resource Manager 
      Identity type: Managed Identity
	  Resource group for managed identity: No.1 name
	  Fill other fields....
	  Save
	  
4. In Yaml

  # Get Sercert key'MY_SECRET_key_01' from Key vault name 'oak-chatgpt-keyvault'
  - task: AzureKeyVault@2
    inputs:
      azureSubscription: <No 3. name> 
      KeyVaultName: 'oak-chatgpt-keyvault'  
      SecretsFilter: 'MY_SECRET_key_01' #use comma to separated list if more than one OR *
      RunAsPreJob: false

 # Use the Sercert 
 - task: AzureStaticWebApp@0
    inputs:
      app_location: $(app_location)
      output_location: $(output_location)
      api_location: $(api_location)
      azure_static_web_apps_api_token: $(MY_SECRET_key_01) #<-- Use that secret , No need to declare a variable MY_SECRET_key_01.
    displayName: 'Deploy to Azure Static Web Apps'