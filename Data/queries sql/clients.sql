/****** Script do comando SelectTopNRows de SSMS  ******/
SELECT CCO.* 

  FROM [Clients] C 
  INNER JOIN ClientCorsOrigins CCO ON CCO.ClientId=C.id
  WHERE ClientName='lab'

  SELECT CCO.* 

  FROM [Clients] C 
  INNER JOIN ClientScopes CCO ON CCO.ClientId=C.id
  WHERE ClientName='lab'

  SELECT CCO.* 

  FROM [Clients] C 
  INNER JOIN ClientRedirectUris CCO ON CCO.ClientId=C.id
  WHERE ClientName='lab'