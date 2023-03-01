package com.market.place.web.controller;

import com.market.place.domain.UserDomain;
import com.market.place.domain.service.AcountService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/acount")
public class AcountController {
    @Autowired
    private AcountService acountService;
    @GetMapping("/status")
    public String status (){
        return "Status Ok";
    }
    @GetMapping("/all")
    public ResponseEntity<List<UserDomain>> getAll(){
        return new ResponseEntity<>(acountService.getAll(), HttpStatus.OK);
    }
    @GetMapping("/active/{active}")
    public  ResponseEntity<List<UserDomain>> getAllUsersActive(@PathVariable("active") int active){
        return acountService.getAllUsersActive(active)
                .map(user -> new ResponseEntity<>(user, HttpStatus.OK))
                .orElse(new ResponseEntity<>(HttpStatus.NOT_FOUND));
    }
}
