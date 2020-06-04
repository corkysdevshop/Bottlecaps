import { Component, Inject, OnInit } from '@angular/core';
import { BottlecapService } from '../../private/my-bottlecaps/bottlecap.service';

@Component({
  selector: 'app-space',
  templateUrl: './space.component.html',
  styleUrls: ['./space.component.css']
})
export class SpaceComponent implements OnInit{

	constructor(private bottlecapService: BottlecapService) { }

	ngOnInit() {
		this.bottlecapService.getBottlecaps(1); //TODO: THIS SHOULD PASS AN ARRAY OF BOTTLCAP IDS AND RETURN AN ARRAY SLICE TO HOLD IN THIS COMPONENT, HOWEVER FOR NOW I'LL JUST REFERENCE THE BOTTLECAP SERVICE TO GET THE IDS TO PLACE IN THE SPACE
	}
	placeBottlecap(bottlecap) {
		console.log("place: ", bottlecap.selectedIndex);
	}
}
