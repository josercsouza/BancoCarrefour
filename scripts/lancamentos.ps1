$ArquivoOrigem = "lancamentos.csv"

# [Net.ServicePointManager]::SecurityProtocol = ([Net.ServicePointManager]::SecurityProtocol -bor [Net.SecurityProtocolType]::Tls12 -bor [Net.SecurityProtocolType]::Tls11)

$urlBase = 'http://localhost:8080/api/Lancamento'
$headers = @{"accept"="*/*"; "Content-Type"="application/json"}

$listaRespContas = Import-Csv ('.\' + $ArquivoOrigem )
$i = $listaRespContas.Count
$logTemp = $ArquivoOrigem + '_log.json' 

echo ('{"itens":[') > $logTemp

foreach ($respConta in $listaRespContas) {
    Write-Host ($i--)  $respConta -ForegroundColor DarkGreen

    $body  = '{'
    $body += '    "dataEfetiva": "'+$respConta.data+'",'
    $body += '    "valor": '+$respConta.valor
    $body += '}'

	echo ('{"dataEfetiva":"' + $respConta.data + '"') >> $logTemp
	echo (',"valor":"'+$respConta.valor+'"') >> $logTemp
	echo (',"retorno":') >> $logTemp
	
    Invoke-WebRequest $urlBase -Method 'POST' -Headers $headers -Body $body | Select-Object -Expand Content >> $logTemp

	echo (' },') >> $logTemp

    Write-Host $url
    Write-Host $body

    Write-Host
    # sleep 2
}

echo ('] }') >> $logTemp
