export class LoginResults {
    token!: string;
    expiration!: Date;
}

export class LoginRequest {
    UserEmail: string | undefined;
    UserPassword: string | undefined;
}