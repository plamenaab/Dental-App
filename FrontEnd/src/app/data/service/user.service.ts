import { Injectable, isDevMode } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { CacheService } from '../../core/services/cache.service';
import { HttpClientService } from '../../core/services/http-client.service';
import { LoginUser, RegisterUser, LoggedUser, UserFullInfo, UserInfo } from '../schema/user';
import { JsonApiService } from './json-api.service';

@Injectable({
    providedIn: 'root'
})
export class UserService {
    constructor(private jsonApiService: JsonApiService, private http: HttpClientService, private _cacheService: CacheService, private router: Router) {
    }

    public getUsers(): Observable<UserInfo[]> {
        return this.jsonApiService.get("/users");
    }

    public getUser(userId: number): Observable<UserFullInfo> {
        return this.jsonApiService.get("/users/id", userId);
    }

    public updateUser(user: UserFullInfo): Observable<UserFullInfo> {
        if (isDevMode()) {
            return this.http.put<UserFullInfo>({ url: 'users/' + user.id, body: user, snackBarMessage: "SuccessUpdateUser" })
        }
    }

    public uploadImage(formData: FormData) {
        if (isDevMode()) {
            return this.http.post({ url: 'users/upload', body: formData, snackBarMessage: "SuccessUpdateImage" })
        }
    }

    public login(userName: string, password: string): Observable<LoggedUser> {
        var user =
        {
            userName: userName,
            password: password
        }
        return this.http.post<LoggedUser>({ url: 'login/Authenticate', body: user, snackBarMessage: "SuccessUpdateUser" })
    }

    public logout() {
        this._cacheService.remove('user');
        this.router.navigate(['/landing'])
    }

    public register(user: RegisterUser): Observable<RegisterUser> {
        var userReg = new RegisterUser();
        return this.http.post<RegisterUser>({ url: 'login/register', body: user, snackBarMessage: "SuccessUpdateUser" })
    }
}