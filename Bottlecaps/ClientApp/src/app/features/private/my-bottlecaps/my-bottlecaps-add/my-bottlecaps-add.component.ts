import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { BottlecapsComponent } from '../bottlecaps/bottlecaps.component';
import { BottlecapService } from '../bottlecap.service';
import { Bottlecap, Profile } from './../../../../shared/models'

@Component({
  selector: 'app-my-bottlecaps-add',
  templateUrl: './my-bottlecaps-add.component.html',
  styleUrls: ['./my-bottlecaps-add.component.css']
})
export class MyBottlecapsAddComponent {

	@ViewChild(BottlecapsComponent, { static: false }) bottlecapComponent;
	constructor(private router: Router,
	            private bottlecapService: BottlecapService) { }

	addBottlecap(newBottlecap) {
		var title = newBottlecap.bottlecapTitle.value;
		var newBottlecapInstance = <Bottlecap>{};
		newBottlecapInstance.title = title;
		newBottlecapInstance.tag = this.bottlecapComponent.tags;
		newBottlecapInstance.link = this.bottlecapComponent.links;
		newBottlecapInstance.profile = new Profile(1); //TODO: RETRIEVE PROFILE ID FOR THIS PARAMETER

		//console.log('in addBottlecap component with: ', newBottlecapInstance);
		this.bottlecapService.addBottlecapToCollection(newBottlecapInstance);
		this.router.navigate(['view-collection']);
	};
}
//interface Bottlecap{
//	bcName: string;
//	bcTags: string[];
//	bcLinks: string[];
//}
