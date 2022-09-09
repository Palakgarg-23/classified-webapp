//response schema for rest api
export class AuthResponse{
    constructor(
        public authToken:string,
        public empid:string
        ){}
}