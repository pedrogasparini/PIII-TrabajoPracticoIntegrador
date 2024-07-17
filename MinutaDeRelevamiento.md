Minuta de Relevamiento

Integrantes:
Pilar López | 53179
Lucas Lovera | 53320
Pedro Ortiz Gasparini | 53283

Contexto

Se trata de una Farmacia web que busca gestionar eficientemente su inventario y las transacciones comerciales. Con este sistema, la empresa busca mejorar la experiencia del cliente, optimizar la gestión de inventario y ventas, y fortalecer su posición en el mercado.

Proceso

Este sistema de gestión para una Farmacia ofrece una plataforma robusta para administrar usuarios con roles diferenciados. Los SysAdmin cuentan con privilegios máximos, permitiéndoles realizar tareas de administración integral. Los Admin, aunque con restricciones comparativas, tienen la capacidad de gestionar aspectos específicos del sistema, como la modificación de productos y el registro de ventas. Los Clientes, por su parte, pueden navegar por la plataforma para realizar compras de productos, lo que se refleja en la clase Purchase, que registra detalles como la fecha de compra, el monto total, el comprador y los artículos adquiridos. Mientras tanto, la clase Product permite a los Admin gestionar el inventario, con información detallada sobre cada artículo, incluyendo su identificación, nombre, precio y disponibilidad en stock. Además, la funcionalidad de registro de ventas, representada por la clase Sale, permite registrar las transacciones realizadas por los Admin, proporcionando un historial completo de todas las ventas realizadas. Este sistema no solo optimiza la gestión de usuarios y productos, sino que también ofrece una visión detallada de las transacciones comerciales, lo que contribuye a una operación eficiente y transparente de la empresa.

Clase User:
Id(): Numero de identificacion del usuario
Username (str): Nombre de usuario del usuario.
name (str): Nombre del usuario.
lastName (str): Apellido del usuario.
email (str): Dirección de correo electrónico del usuario.
password (str): Contraseña del usuario.
type (str): Tipo de usuario, puede ser "SysAdmin", "Admin" o "Cliente".

Clase SysAdmin:
Hereda de la clase User.
Tiene permisos máximos en la aplicación.

Clase Admin:
Hereda de la clase User.
Puede realizar modificaciones en algunas áreas de la aplicación, pero no todas.
Representa a los empleados del negocio.

Clase Cliente:
Hereda de la clase User.
Además de los atributos de User, tiene:
address (str): Dirección del cliente.

Clase SaleDetail:
Id(int): Identificador de la compra
Date(int):Fecha de la compra
Client(str):Cliente que realiza la compra

Clase Product:
Representa un producto en el inventario.
Tiene los siguientes atributos:
id (int): Identificador único del producto.
name (str): Nombre del producto.
price (float): Precio del producto.
stockAvailable (int): Cantidad disponible en stock.
stockList (list): Lista de información detallada del stock.

Clase Sale:
Representa una venta realizada por un administrador.
Tiene los siguientes atributos:
Amount(int): Cantidad de productos vendidos.
Total(float): Monto total de la venta.
productSell (str): Producto vendido.
