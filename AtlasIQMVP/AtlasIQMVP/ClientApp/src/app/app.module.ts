import { Routes } from '@angular/router'
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { SidebarModule } from 'ng-sidebar';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';

export const appRoutes: Routes = [
  { 
    path: '', 
    component: HomeComponent, 
    pathMatch: 'full' 
  },
  { 
    path: 'counter', 
    component: CounterComponent 
  },
  { 
    path: 'fetch-data', 
    component: FetchDataComponent 
  },
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
    SidebarModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
