namespace ProyectoApi_KN.App_Start
{
    internal class SymmetricSecurityKey
    {
        private byte[] bytes;

        public SymmetricSecurityKey(byte[] bytes)
        {
            this.bytes = bytes;
        }
    }
}