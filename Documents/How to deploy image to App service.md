## After push a Image from Azure Container Registry.

1. In **Azure Container Registry**
   Setting > Access keys : Enable **Admin user** 
2. In the **App service** 
     Setting > Environment varaibles
     Set container registry admin credentials using information from no 1.
     - DOCKER_REGISTRY_SERVER_PASSWORD
     - DOCKER_REGISTRY_SERVER_USERNAME 
     - DOCKER_REGISTRY_SERVER_URL
*It supose to working now, However If not Try apply following steps*
     - 
3. In the **App service** 
     identity section >  system assigned :  change status to On.
     Copy the principal Id, It will be used on step 4
4 In **Azure Container Registry** 
     IAM > Add role assigment add **ACR pull role** > Managed Indentity > Select members > Paste principal Id of App Service on step 3.
