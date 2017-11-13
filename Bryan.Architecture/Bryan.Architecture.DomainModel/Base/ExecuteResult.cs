using Bryan.Architecture.DomainModel.Base.Enum;

namespace Bryan.Architecture.DomainModel.Base
{
    /// <summary>The execute result.</summary>
    /// <typeparam name="T">Data</typeparam>
    public class ExecuteResult<T>
    {
        /// <summary>Gets or sets the status.</summary>
        public ExcuteResultStatus Status { get; set; }

        /// <summary>Gets or sets the message.</summary>
        public string Message { get; set; }

        /// <summary>Gets or sets the data.</summary>
        public T Data { get; set; }
    }
}