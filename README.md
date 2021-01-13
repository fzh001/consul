consul agent –server -ui -bootstrap-expect=1 -data-dir D:\consul\ConsulData  –client=0.0.0.0 -bind=127.0.0.1 –datacenter=dc1 -config-dir D:\consul\ConsulData\config

dotnet PatrickLiu.MicroService.ServiceInstance.dll --urls="http://*:5728" --ip="127.0.0.1" --port=5728

dotnet PatrickLiu.MicroService.AuthenticationCenter.dll --urls="http://*: 7299" --port=7299

dotnet PatrickLiu.MicroService.Gateway.dll --urls=http://*:6297 --port=6297
