package com.market.place.domain.service;

import com.market.place.domain.UserItem;
import com.market.place.domain.repository.UserRepository;
import com.market.place.persistence.entity.User;
import org.springframework.beans.factory.annotation.Autowired;

import java.util.List;

public class AcountService {
    @Autowired
    private UserRepository userRepository;
    public List<UserItem> getAll(){
        return userRepository.getAll();
    }
}
