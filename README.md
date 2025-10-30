Build and run without debugging Ctrl + F5

Same azure function runs twice with different environment variables and content root both these will work

1
http://localhost:6074/api/Function1
Welcome to Azure Functions! Example environment var: I am the environment var from the first one! Example json var: I am the json in the first one!

2
http://localhost:6075/api/Function1
Welcome to Azure Functions! Example environment var: I am the environment var from the second one! Example json var: I am the json in the second one!

If you run with debugging just F5 they fight over the tmp file used to get the process id and only one will start, then starting the second will kill the first.