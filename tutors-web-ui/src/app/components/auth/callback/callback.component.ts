import { Component, OnInit } from '@angular/core';
import { OAuthService } from 'src/app/services/oauth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-callback',
  templateUrl: './callback.component.html',
  styleUrls: ['./callback.component.css']
})
export class CallbackComponent implements OnInit {

  constructor(private oauthService:OAuthService, private router: Router) { }

  ngOnInit() {
    console.log('component');
    this.oauthService.identityCallback().subscribe(p=>{
      this.oauthService.setAccessToken(p);
      this.router.navigate(["/"]);
    });
  }

}
