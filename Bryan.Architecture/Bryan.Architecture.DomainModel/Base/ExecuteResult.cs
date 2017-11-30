using Bryan.Architecture.DomainModel.Base.Enum;

namespace Bryan.Architecture.DomainModel.Base
{
    /// <summary>The execute result.</summary>
    /// <typeparam name="T">Data</typeparam>
    public class ExecuteResult<T>
    {
        /// <summary>Initializes a new instance of the <see cref="ExecuteResult{T}"/> class.</summary>
        /// <param name="status">The status.</param>
        /// <param name="data">The data.</param>
        /// <param name="message">The message.</param>
        public ExecuteResult(ExcuteResultStatus status = ExcuteResultStatus.Success, T data = default(T), string message = "")
        {
            this.Status = status;
            this.Data = data;
            this.Message = message;
        }

        /// <summary>Gets or sets the status.</summary>
        public ExcuteResultStatus Status { get; set; }

        /// <summary>Gets or sets the data.</summary>
        public T Data { get; set; }

        /// <summary>Gets or sets the message.</summary>
        public string Message { get; set; }
    }
}