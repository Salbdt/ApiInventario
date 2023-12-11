# Imagen Sql Serve corriendo en Docker


Para utilizar Sqlserver corriendo en docker basta con seguir estos sencillos pasos

1. Descargar e instalar [Docker Desktop]( https://www.docker.com)  para el sistema operativo a utilizar, Windows, Linux o MacOs

2. Validar que esta instalado abriendo una terminal en VS y escribiendo el comando 
    `docker --version`
    les parecera algo como esto `Docker version 23.0.5, build bc4487a`

3. Descagar de [docker hub](https://hub.docker.com) la imagen de Sql Serve a tulizar en lo personal uso la siguiente [Azure SQL Edge](https://hub.docker.com/_/microsoft-azure-sql-edge)

4. En la termina en VSCode ejecutar el siguiente comando, sustituir el password por un password seguro
    
        docker run --cap-add SYS_PTRACE -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD=yourStrongxxPassword' -p 1433:1433 --name azuresqledge -d mcr.microsoft.com/azure-sql-edge

5. Ejecutar la imagen desde Docker Desktop, como lo muestro en la clase.

6. Cualquier duda, escribeme para apoyarte.