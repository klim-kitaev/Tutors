import { Component, OnInit } from '@angular/core';
import { OAuthService } from './services/oauth.service';
import { Router, ChildActivationStart, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  
  title = 'tutors-web-ui';

  private userName: string;
  private isAuth: boolean;

  constructor(private oauthService: OAuthService, private router:Router) { 
    this.router.events.subscribe(e => {
      if(e instanceof NavigationEnd){
        this.getName();
      }
    });   
  }

  ngOnInit(): void {
    this.getName();
   console.log('app-component init'); 
  }

  public login() {
    this.oauthService.login();
  }

  public logout() {
    this.oauthService.logout();
  }

  public get name() {
    return this.userName;
  }

  public get IsAuth(){
    return this.isAuth;
  }


  private getName(){
     this.oauthService.getUser().subscribe(p=>{
       this.isAuth = p != null ;      
       this.userName = this.isAuth ? p.profile.name : "";
      });
  }

  // public checkAuth(){
  //   console.log("is auth " + this.isAuth)
  //   console.log("name: " + this.userName)
  //   console.log("access token " + this.oauthService.token)
  //   this.oauthService.getUser().subscribe(p=>{
  //     console.log("User "+ JSON.stringify(p))
  //   })
  // }



}
