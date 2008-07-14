namespace DALHelper
{
    public interface IEdge
    {
        IVertex From
        { 
            get;
        }

        IVertex To
        { 
            get;
        }
    }
}
