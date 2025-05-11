using DAL;

namespace WebAPI
{
    public static class Parametros
    {
        //public static string cadenaConexion = @"Server=localhost;UserId=root1;Password=21021192;Port=3306;Database=delegacion;";

#if DEBUG
        public static string cadenaConexion = @"Server=localhost;UserId=root1;Password=21021192;Port=3306;Database=delegacion1;";
#else
        public static string cadenaConexion = @"Server=db17388.public.databaseasp.net; Database=db17388; Uid=db17388; Pwd=L-p86wZ#_4dK; SslMode=Preferred;";
#endif
        public static TipoBD TipoBD = TipoBD.MySql;

        public static FabricRepository FabricaRepository = new FabricRepository(cadenaConexion, TipoBD);
    }
}
