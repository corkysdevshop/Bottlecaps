import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router'

//@Injectable({
//  providedIn: 'root'
//})

@Injectable()
export class AuthService {
	baseUrl;
	constructor(private http: HttpClient, private router: Router, @Inject('BASE_URL') baseUrl: string) {
		this.baseUrl = baseUrl;
	}

	get isAuthenticated() {
		return !!localStorage.getItem('token')
	}

	register(credentials) {
		console.log('inside service register method')
		var options = { 'Content-Type': undefined
	};
		this.http.post<any>(`account/register`, credentials).subscribe(
			data => {
			  console.log('response: ',JSON.parse(data.Content));
			  //this.authenticate(res)
			},
			error => {
				console.log('error: ', error);
			},
			() => {
				console.log('completed');
			}
		)
	}

	login(credentials) {
		console.log('inside autho.service.ts login()')
   
		this.authenticate("eyJhbGciOiJub25lIiwidHlwIjoiSldUIn0.e30."); // mocked authorization JWT Token

		//this.http.post<any>(`account/login`, credentials).subscribe(res => {
		//		console.log("response: ",res); //TODO: FIGURE OUT WHY THISIS GIVING
		//		//SyntaxError: Unexpected token e in JSON at position 0
		//		//at JSON.parse(<anonymous>)
		//		//at XMLHttpRequest.onLoad(https://localhost:44327/vendor.js:9948:51)
		//		//	at ZoneDelegate.invokeTask(https://localhost:44327/polyfills.js:3240:31)
		//		//		at Object.onInvokeTask(https://localhost:44327/vendor.js:68379:33)
		//		//			at ZoneDelegate.invokeTask(https://localhost:44327/polyfills.js:3239:60)
		//		//				at Zone.runTask(https://localhost:44327/polyfills.js:3017:47)
		//		//					at ZoneTask.invokeTask[as invoke](https://localhost:44327/polyfills.js:3314:34)
		//		//						at invokeTask (https://localhost:44327/polyfills.js:4452:14)
		//		//							at XMLHttpRequest.globalZoneAwareCallback (https://localhost:44327/polyfills.js:4489:21)			
                
		//		//localStorage.setItem('token', res);
		//	  //this.authenticate(res)
		//	}
		// )
	}

	authenticate(res) {
		localStorage.setItem('token', res)

		this.router.navigate(['dashboard'])
	}

	logout() {
		localStorage.removeItem('token')
	}
}
