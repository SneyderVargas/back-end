package com.market.place.domain.service;

import com.market.place.domain.UserDomain;
import com.market.place.domain.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class AcountService {
    @Autowired
    private UserRepository userRepository;
    public List<UserDomain> getAll(){
        return userRepository.getAll();
    }
    public Optional<List<UserDomain>> getAllUsersActive(int active){
        return userRepository.getAllUsersActive(active);
    }
    public UserDomain save(UserDomain userDomain){return userRepository.save(userDomain);}
}
