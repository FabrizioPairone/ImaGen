namespace ImaGen.Styles
{

    /// <summary>
    /// Enum that rappresent the resize method of Image.
    /// </summary>
    public enum ResizeMethod
    {

        /// <summary>
        /// Keep proportions during the resize.
        /// </summary>
        KeepProportions,

        /// <summary>
        /// Scaled the image to targetSize.
        /// </summary>
        Scaled,

        /// <summary>
        /// Scaled the image to max targetSize keeping proportions
        /// </summary>
        ScaledWithProportions

    }
}
