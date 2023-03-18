package com.market.place.persistence;

import com.market.place.domain.UserDomain;
import com.market.place.domain.repository.UserRepository;
import com.market.place.persistence.crud.UserCrudRepository;
import com.market.place.persistence.crud.UserPaginationRepository;
import com.market.place.persistence.entity.UserEntity;
import com.market.place.persistence.mapper.UserItemMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;
@Repository
public class UsersRepository implements UserRepository {
    @Autowired
    private UserCrudRepository userCrudRepository;
    @Autowired
    private UserPaginationRepository userPaginationRepository;
    @Autowired
    private UserItemMapper mapper;
    @Override
    public List<UserDomain> getAll() {
        List<UserEntity> usersDomain = (List<UserEntity>) userCrudRepository.findAll();
        return mapper.toUsersDomain(usersDomain);
    }
    @Override
    public Optional<List<UserDomain>> getAllUsersActive(int active){
        Optional<List<UserEntity>> users = userCrudRepository.findByActive(active);
        return users.map(user -> mapper.toUsersDomain(user));

    }
    @Override
    public UserDomain save(UserDomain userDomain) {
        UserEntity user = mapper.toUserEntity(userDomain);
        return mapper.toUserDomain(userCrudRepository.save(user));
    }

    @Override
    public Optional<Page<UserEntity>> getPagination(Pageable pageable) {
        Page<UserEntity> usersDomainPage = (Page<UserEntity>) userPaginationRepository.findAll(pageable);
        return Optional.of(usersDomainPage);
    }


}
