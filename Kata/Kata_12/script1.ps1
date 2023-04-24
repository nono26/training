Set-StrictMode -Version "latest"
Clear-Host
. $PSScriptRoot\common.ps1
Write-Host "Getting Cosmos context"
$primaryKey = ConvertTo-SecureString -String $Global:CosmosAuthenticationKey -AsPlainText -Force
$CosmosContext=New-CosmosDbContext -Account $Global:CosmosAccount -Database $Global:CosmosDatabaseName -Key $primaryKey -EndpointHostname $Global:CosmosEndpoint
Write-Host ("Got Cosmos context for Cosmos account: '{0}'  and database: '{1}'" -f $CosmosContext.Account, $CosmosContext.Database)
function GetAllDocuments {
    $ids= @()
    #Get appUserId, partnerCode and StatementDate
    $duplicatedDetailsQuery= "SELECT d.appUserId, d.partnerCode, d.statementDate
    from (
    Select COUNT(1) AS jongel,c.appUserId, c.partnerCode, c.statementDate
    from c
    group by c.appUserId, c.partnerCode, c.statementDate) d where d.jongel > 1"
    
    $duplicatedDetails=Get-CosmosDbDocument -Context $CosmosContext -CollectionId $Global:CosmosCollectionName -QueryEnableCrossPartition $true -Query $duplicatedDetailsQuery
    Start-Sleep -Milliseconds 1000

    foreach($detail in $duplicatedDetails){
        $querySource="SELECT top 1 c.id FROM c where c.appUserId ='"+$detail.appUserId+"' AND c.partnerCode='"+$detail.partnerCode +"' AND c.statementDate ='"+$detail.statementDate+"'"

        $allDocs = Get-CosmosDbDocument -CollectionId $Global:CosmosCollectionName -QueryEnableCrossPartition $true -Query $querySource -Context $CosmosContext
    
        if ($null -ne $allDocs)
        {
            $ids+=$allDocs.id
        }
        Start-Sleep -Milliseconds 500
    }

return $ids
}
function WriteDocuments{
    param($documents)
    if($null -ne $Global:FolderPath ){
    $time=Get-Date -Format "MM_dd_yyyy_HH_mm"
    $filePath= $Global:FolderPath+$time+".txt"
    New-Item $filePath
    Set-Content $filePath $documents
    }
}

function  DeleteDocuments {
param ($documents) 
foreach ($doc in $documents) {
#Remember to specify Partition key
Remove-CosmosDbDocument -Context $CosmosContext -CollectionId $Global:CosmosCollectionName -Database $Global:CosmosDatabaseName -PartitionKey $doc 
}
}
$documents=GetAllDocuments
Write-Host ("Found {0} documents in the Container {1}" -f $documents.length,$Global:CosmosCollectionName)
WriteDocuments -documents $documents
DeleteDocuments -documents $documents
Write-Host "Deletion complete"