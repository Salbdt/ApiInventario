# Conectarse a la base de datos

## Usuario y contraseña
"DefaultConnection": "Server=Equipo\\SQLEXPRESS; Database=InventoryDB; User ID=sa; Password=clave; Encrypt=False"

## Ingreso con autenticación de Windows
"DefaultConnection": "Server=Equipo\\SQLEXPRESS; Database=InventoryDB; User ID=sa; Password=clave; TrustServerCertificate=True"

## Proyecto
Colocar:
    <PropertyGroup>
        <InvariantGlobalization>false</InvariantGlobalization>
    </PropertyGroup>