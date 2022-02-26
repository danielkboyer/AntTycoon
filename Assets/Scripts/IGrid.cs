public interface IGrid
{

    public bool IsVisible { get; set; }
    /// <summary>
    /// What type of object this is
    /// </summary>
    /// <returns></returns>
    GridType GetType();
    /// <summary>
    /// How far this grid object can see
    /// </summary>
    /// <returns></returns>
    int GetVisibility();
    /// <summary>
    /// the size of the grid object on the grid
    /// </summary>
    /// <returns></returns>
    int GetSize();
}