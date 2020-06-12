import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';

import { CoreModule } from './core/core.module';
import { NavMenuComponent } from './core/nav-menu/nav-menu.component';
import { HomeComponent } from './core/home/home.component';

import { SharedModule } from './shared/shared.module';


import { FeaturesModule } from './features/features.module';
import { AuthService } from './shared/auth.service';


@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
	  FormsModule,
    CoreModule,
    SharedModule,
	  FeaturesModule,
  ],
  providers: [AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
