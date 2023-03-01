namespace AccountControll.Dtos
{
    public class ApiCollectionResponseDto
    {
        public int Size { get; set; }
        public object[] Value { get; set; }

        // Variables de respuestas para Json
        public bool error { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }

        public static ApiCollectionResponseDto Create(object value)
        {
            return new ApiCollectionResponseDto
            {
                Size = 1,
                Value = new object[] { value }
            };
        }

        public static ApiCollectionResponseDto Create(int size, object[] value)
        {
            return new ApiCollectionResponseDto
            {
                Size = size,
                Value = value
            };
        }

        /**
         * Devuelve error en la respuesta JSON
         */
        public static ApiCollectionResponseDto ErrorResponse(string message)
        {
            return new ApiCollectionResponseDto
            {
                error = true, // Si existe Error
                Message = message,
                Value = null,
                Size = 0,
            };
        }

        public static ApiCollectionResponseDto ResponseOk(string message, object[] value)
        {
            return new ApiCollectionResponseDto
            {
                error = false, // NO existe Error 
                Message = message,
                Value = value,
                Size = value.Length,
                Details = "Error de sistema"
            };
        }

        /**
         Devuelve un objeto creado correctamente
         */
        public static ApiCollectionResponseDto CreateOk(string message, object value)
        {
            return new ApiCollectionResponseDto
            {
                error = false, // NO existe Error 
                Message = message,
                Value = new object[] { value },
                Size = 1,
            };
        }
        public static ApiCollectionResponseDto CreateOk(string message, object value, int size)
        {
            return new ApiCollectionResponseDto
            {
                error = false, // NO existe Error 
                Message = message,
                Value = new object[] { value },
                Size = size,
            };
        }
        //*---------------------- respuesta solo mensaje de información ------------------------//
        public static ApiCollectionResponseDto ResponseInfoOk(string message)
        {
            return new ApiCollectionResponseDto
            {
                error = false, // No exite error
                Message = message
            };
        }
        //---------------------- respuesta solo mensaje de información ------------------------*//
        //*---------------respuestas estandarizada -------------------------//
        public static ApiCollectionResponseDto Response(bool error, object value, string message, string details)
        {
            return new ApiCollectionResponseDto
            {
                error = error, // entrga de estado de respuesta
                Message = message,
                Value = new object[] { value },
                Details = details,
            };
        }
        //---------------respuestas estandarizada -------------------------*//
    }
}
