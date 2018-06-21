namespace Snake201806.Model
{
    /// <summary>
    /// ez a típus jelzi a kígyó fejének az irányát
    /// </summary>
    enum SnakeHeadDirectionEnum
    {
        Up,
        Down,
        Left,
        Right,
        /// <summary>
        /// A játék kezdetén a kígyó egy helyben áll, nem mozog
        /// </summary>
        InPlace
    }
}