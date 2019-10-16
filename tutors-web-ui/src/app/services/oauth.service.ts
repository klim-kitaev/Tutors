import { UserManagerSettings, UserManager, User } from 'oidc-client';
import { from, Observable } from 'rxjs';
import { AUTH_CONFIG } from './auth-config';
import { Inject } from '@angular/core';


export class OAuthService {

    private userManager: UserManager;
    private access_token: string; 

    constructor(@Inject(AUTH_CONFIG) settings: UserManagerSettings) {
        this.userManager = new UserManager(settings);
        // this.getUser().subscribe(p => {
        //     this.access_token = p == null ? "" : (p.access_token || "");
        // });
        this.userManager.getUser().then(p=>this.setAccessToken(p));  
    }

    login(): Observable<any> {
        return from(this.userManager.signinRedirect());
    }

    setAccessToken(user:User){
        this.access_token = user == null ? "" : (user.access_token || "");
    }

    getUser(): Observable<User> {
        //console.log('get-user');
        return from(this.userManager.getUser());
    }

    logout(): Observable<any> {
        return from(this.userManager.signoutRedirect());
    }

    identityCallback(): Observable<User>{
        return from(this.userManager.signinRedirectCallback());
    }

    get token(): string {                     
        return this.access_token;
    }






}