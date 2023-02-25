package com.market.place.web.controller;

import com.market.place.domain.UserItem;
import com.market.place.domain.service.AcountService;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/acount")
public class AcountController {
    private AcountService acountService;
    @GetMapping("/status")
    public String status (){
        return "Status Ok";
    }
    @GetMapping("/all")
    public ResponseEntity<List<UserItem>> getAll(){
        return new ResponseEntity<>(acountService.getAll(), HttpStatus.OK);
    }
}
